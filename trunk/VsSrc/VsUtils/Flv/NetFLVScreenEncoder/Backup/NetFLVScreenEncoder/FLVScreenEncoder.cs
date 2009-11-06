using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace NetFLVScreenEncoder
{
    /// <summary>
    /// The FLVScreenEncoder class encapsulates writing frames to the flv format. Currently the FLVScreenEncoder
    /// can output directly to file (.flv file format) or stream to a media server such as Red5.
    /// </summary>
    public class FLVScreenEncoder
    {

        /*Encoding state parameters */
        private bool encodeInProgress = false;

        private bool streamLive = false;

        private bool streamFile = false;
        /* End Encoding state Parameters */

        private string file_name;
        /// <summary>
        /// RTMPClient for streaming to a flash media server.
        /// </summary>
        private ConnectionProtocol client;

        /// <summary>
        /// The output stream (to file)
        /// </summary>
        private Stream output;

        /// <summary>
        /// A high performance timer.
        /// </summary>
        private HighPerformanceTimer timer;

        /// <summary>
        /// The paramters this library will use for the encoding session.
        /// </summary>
        private FLVEncoderParams par;

        /// <summary>
        /// An array of bytes of the previous frame.
        /// </summary>
        private byte[] previousFrame;

        /// <summary>
        /// A MemoryStream to the backing memory buffer to write encoded data to.
        /// </summary>
        private MemoryStream memoryStream;

        /// <summary>
        /// The backing array for the memory stream (where information is output).
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// An uncompressed block buffer.
        /// </summary>
        private byte[] destBlockBuffer;

        /// <summary>
        /// An uncompressed block buffer.
        /// </summary>
        private byte[] srcBlockBuffer;

        /// <summary>
        /// Contains how many frames have been written to file.
        /// </summary>
        private int frameCount = 0;

        /// <summary>
        /// Contains the last keyFrameTime
        /// </summary>
        private int lastKeyFrameTime = 0;

        /// <summary>
        /// Contains the last time stamp/
        /// </summary>
        private double lastTimeStamp = 0;


        /// <summary>
        /// The last time stamp that was encoded.
        /// </summary>
        public double LastTimeStamp
        {
            get
            {
                return lastTimeStamp;
            }
        }

        /// <summary>
        /// The number of frames that have been encoded since the first BeginX has been called.
        /// </summary>
        public int TotalFramesEncoded
        {
            get
            {
                return frameCount;
            }
        }

        /// <summary>
        /// The Paramters that the library will use during the encoding process.
        /// </summary>
        public FLVEncoderParams EncoderParameters
        {
            get
            {
                return this.par;
            }
            set
            {
                this.par = value;
            }
        }

        /// <summary>
        /// Determines whether or not the library is currently encoding ( either live or to file).
        /// </summary>
        public bool IsEncoding
        {
            get
            {
                return this.encodeInProgress;
            }
        }

       

        public void call(string method, params object[] oparams)
        {
            if (this.streamLive && this.encodeInProgress)
                this.client.call(method, null, oparams);
        }

        /// <summary>
        /// Contains the data of the previous tag that was written to file,
        /// this is to determine the size when writing the tag data
        /// to the FLV file body.
        /// </summary>
        private FLVTag tag;

        public FLVScreenEncoder(FLVEncoderParams par)
        {
            //save the parameters
            this.par = par;

            //set the previous frame to null (ie make sure it's blank and clear memory)
            this.previousFrame = null;

            //initialize enough data for the buffer
            buffer = new byte[(int)(par.VideoWidth * par.VideoHeight * 3 * 1.001 + 700)];

            //create the memory stream
            memoryStream = new MemoryStream(buffer);

            //create a block data buffer for image blocks
            destBlockBuffer = new byte[(int)((32 * 32 * 4) * 1.001 + 300)]; //required (for safety)

            //create the src block data buffer
            srcBlockBuffer = new byte[(int)((32 * 32 * 4) * 1.001 + 300)]; //required (for safety)

        }

        /// <summary>
        /// Begins the live stream using the information previously set in the FLVEncoderParams.
        /// If there was an error connecting to the server, than false is returned.
        /// </summary>
        /// <returns>True if encoding has begun properly / safely.</returns>
        public bool BeginLiveStream(string[] c_params)
        {

            if (!streamFile)
            {
                timer = new HighPerformanceTimer();
                timer.Start(); //begin our timer (times are encoded).
                this.frameCount = 0;
            }

            Console.WriteLine(this.EncoderParameters.StreamingParams.Protocol);
            client = ConnectionProtocol.getProtocolHandler(
                this.EncoderParameters.StreamingParams.Protocol);
            client.ConnectionParameters = this.EncoderParameters.StreamingParams;
            Console.WriteLine("Connecting with: " + client.ProtocolName);
            if (!client.connect(c_params))
            {
                return false;
            }
           
            
            

            //turn on live streaming
            this.streamLive = true;

            //set the encoding progress to true
            this.encodeInProgress = true;

            //return success
            return true;
        }

        /// <summary>
        /// Begins creating a local .flv file based on the file path specified in teh FLVEncoderParams.
        /// </summary>
        /// <returns>True if encoding has begun, false is an error was encountered.</returns>
        public bool BeginFileEncode()
        {
            if (!streamLive)
            {
                //reset the framecount
                this.frameCount = 0;
                timer = new HighPerformanceTimer();
                
            }
            //create a new file stream to the file
            FileStream fs = new FileStream(this.EncoderParameters.FileParams.FilePath, FileMode.Create);
            this.file_name = EncoderParameters.FileParams.FilePath;
            //save the output
            output = fs;

            //write the header information
            FLVHeader.WriteHeader(this.output);

            //write 4 0's for the tag size (this refers to the previous tag, which in this case is 0 since no tag is before)
            output.WriteByte(0);
            output.WriteByte(0);
            output.WriteByte(0);
            output.WriteByte(0);
            output.Flush();

            if(!streamLive)
                timer.Start(); //begin our timer (times are encoded).
            //set streamFile flag to true
            this.streamFile = true;

            //set the encoding status
            this.encodeInProgress = true;

            //return success
            return true;
        }



        /// <summary>
        /// Terminates the encoding process and closes the output and live streams.
        /// </summary>
        /// <returns>True if the encoding completed succesfully. False if it wasn't encoding in the first place.</returns>
        public bool EndEncode()
        {
            if (!encodeInProgress)
                return false;

            System.GC.Collect();

            //if streaming live
            if (streamLive)
            {
                client.disconnect();
                streamLive = false;
            }

            //if streaming to file
            if (streamFile)
            {
                output.Close();
                streamFile = false;
            }

            //stop the timer
            timer.Stop();


            this.encodeInProgress = false;
            //reset the current FLVTag
            this.tag = null;

            return true;


        }


        /// <summary>
        /// Adds the given frame to the encoding in process. The proper time stamp is handled for this and is
        /// relevnant to the time BeginEncode() was called. If enough information has changed (ie all of the blocks)
        /// in this image, then a key frame is used. Otherwise interblocks are sent to save as much information as possible.
        /// </summary>
        /// <param name="frame">A bitmap array, of the frame to be processed.</param>
        /// <returns>The time in ms to encode the frame or -1 if an error occured.</returns>
        public double EncodeFrame(byte[] frame)
        {
            if ((!streamFile && !streamLive) || !encodeInProgress)
            {
                return -1;
            }
            if (frame.Length < par.VideoHeight * par.VideoWidth * par.SourceBytesPerPixel)
            {
                return -1;
            }

            double start = timer.Duration;

            //reset the buffer
            memoryStream.Position = 0;

            //reset the isKeyFrame flag
            bool isKeyFrame = false;

            //determine whether or not to send a key frame
            if (frameCount == 0) //if this is the first frame
                isKeyFrame = true;

            //if the duration has passed the frame frequency
            if (timer.Duration - lastKeyFrameTime > par.KeyFrameFrequency * 1000)
            {
                //encode a keyframe
                isKeyFrame = true;

                //set the last key frame time (now)
                lastKeyFrameTime = (int)timer.Duration;

                System.GC.Collect();
            }


            //set up the new tag
            tag = new FLVTag(FLVTag.TAGTYPE_VIDEO, frame, this.previousFrame,
                (frameCount > 0) ? (int)timer.Duration : 0, par.VideoWidth, par.VideoHeight,
                srcBlockBuffer, destBlockBuffer, isKeyFrame, par.CompressionLevel, par.SourceBytesPerPixel);

            //write the tag to the inmemory buffer (faster seeks)
            tag.writeTag(memoryStream);

            //get the size of the tag
            int tagSize = tag.getTagSizeInBytes();

            //write the tag in memory out to file
            //and only if information is changed (no point writing an empty frame and
            //wasting space
            if (tag.isFrameDirty())
            {
                if (streamFile)
                {
                    this.output.Write(buffer, 0, (int)memoryStream.Position);
                    this.output.WriteByte((byte)(tagSize >> 24));
                    this.output.WriteByte((byte)(tagSize >> 16));
                    this.output.WriteByte((byte)(tagSize >> 8));
                    this.output.WriteByte((byte)(tagSize));
                    this.output.Flush();
                }

                if (streamLive)
                {
                    try
                    {
                        client.sendFLVTag(buffer, tag); //dont need the size
                    }
                    catch (Exception e)
                    {
                        this.streamLive = false;
                        Console.WriteLine(e);
                        throw e;
                    }
                }

            }
            //increment the frame counter
            frameCount++;


            //store the frame for comparison
            this.previousFrame = frame;

            //store the last timestamp
            this.lastTimeStamp = timer.Duration;

            //return the length it took to encode the frame
            return timer.Duration - start;

        }

        /// <summary>
        /// Appends another frame / or tag to the current FLV file. Instead of using
        /// built in timing mechanisms within the class itself, a timestamp value
        /// can be used to override the "pre calculated" time stamp.
        /// </summary>
        /// <param name="frame">A raw array of pixel data to encode.</param>
        /// <param name="timestamp">The time at which this frame will apply.</param>
        /// <returns>The time in ms to encode the frame, or -1 if an error occured.</returns>
        public double EncodeFrame(byte[] frame, long timestamp)
        {
            if ((!streamFile && !streamLive) && !encodeInProgress)
            {
                return -1;
            }

            //make sure the buffer represents the "supposed" video dimensions
            //if its too small, return an error
            if (frame.Length < par.VideoHeight * par.VideoWidth * par.SourceBytesPerPixel)
            {
                return -1;
            }

            //record the time at the "start" of encoding of this frame
            double start = timer.Duration;

            //reset the buffer
            memoryStream.Position = 0;

            bool isKeyFrame = false;
            //determine whether or not to send a key frame

            if (frameCount == 0) //if this is the first frame
                isKeyFrame = true;


            //if the duration has passed the frame frequency
            if (timestamp - lastKeyFrameTime > par.KeyFrameFrequency * 1000)
            {
                isKeyFrame = true;
                lastKeyFrameTime = (int)timestamp;
                System.GC.Collect();
            }


            //set up the new tag
            tag = new FLVTag(FLVTag.TAGTYPE_VIDEO, frame, this.previousFrame,
                (frameCount > 0) ? (int)timestamp : 0, par.VideoWidth, par.VideoHeight,
                srcBlockBuffer, destBlockBuffer, isKeyFrame, par.CompressionLevel, par.SourceBytesPerPixel);

            //write the tag to the inmemory buffer (faster seeks)
            tag.writeTag(memoryStream);

            //get the size of the tag
            int tagSize = tag.getTagSizeInBytes();

            //write the tag in memory out to file
            //and only if information is changed (no point writing an empty frame and
            //wasting space)
            if (tag.isFrameDirty())
            {
                if (streamFile)
                {
                    output.Write(buffer, 0, (int)memoryStream.Position);
                    this.output.WriteByte((byte)(tagSize >> 24));
                    this.output.WriteByte((byte)(tagSize >> 16));
                    this.output.WriteByte((byte)(tagSize >> 8));
                    this.output.WriteByte((byte)(tagSize));
                    this.output.Flush();

                }
                if (streamLive)
                {
                    try
                    {
                        client.sendFLVTag(buffer, tag); //dont need the size
                    }
                    catch (Exception e)
                    {
                        this.streamLive = false;
                        throw e;
                    }
                }

            }

            //increment the frame counter
            frameCount++;

            //store the frame for comparison
            this.previousFrame = frame;

            //store the timestamp of this encoded frame
            this.lastTimeStamp = timestamp;

            //return the duration of of the this frame's encode time
            return timer.Duration - start;
        }

    }
}