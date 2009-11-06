using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using System.IO.Compression;
namespace NetFLVScreenEncoder
{

    class FLVScreenVideoPacket : FLVAbstractDataPacket
    {
        //Pixel width of each block in the grid.
        //this value is stored as(actualWidth  / 16) -1
        //we want a 32 widht block (32 / 16) - 1 = 1;
        private byte BlockWidth = 1;

        //Pixel width of the full image
        private ushort ImageWidth;

        //Pixel height of each block in the grid
        //this value is stored as (actualHeight / 16) -1
        private byte BlockHeight = 1;

        //Pixel height of the full image
        private ushort ImageHeight;

        //Array of image data
        private byte[] currentFrame;

        //Data to compare to the previous frame
        private byte[] previousFrame;

        //Array of src block pixel information before compression
        private byte[] srcBuff;

        //Array Buffer after block pixel data has been compressed
        private byte[] destBuff;

        //KeyFrame constant value
        private const byte KEY_FRAME = 16;

        //Interframe constant value
        private const byte INTER_FRAME = 32;

        //Codec ID for teh FLV Screen Video Bitstream codec
        private const byte CODEC_ID_SCREEN = 3;

        private bool writeKeyFrame = true;

        private int compressionLevel = 5;

        private bool dirty_block = false;

        private bool frame_dirty = false;

        private byte bpp;

        /// <summary>
        /// Zlib dll import for compression of an array of data.
        /// </summary>
        /// <param name="dest">The destination buffer for the compressed bytes.</param>
        /// <param name="destLength">Size of the destination buffer passed as a pointer.</param>
        /// <param name="src">The source buffer of the bytes to be compressed.</param>
        /// <param name="srcLength">The Length of the source buffer.</param>
        /// <param name="level">The compression level from 1-9. 1 being quickest, 9 being highest compression.</param>
        /// <returns>Places the compressed bytes into the destination buffer.The destination Length paramter will hold the length of the compressed data. </returns>
        [DllImport("zlibwapi.dll")]
        public static extern int compress2(byte[] dest, ref int destLength, byte[] src, int srcLength, int level);


        /// <summary>
        /// Contains the amount of bites that this packet contains.
        /// </summary>
        private int Size = 0;

        /// <summary>
        /// Calculates the size of this video packet.
        /// </summary>
        /// <returns>The size, in bytes, of this video packet.</returns>
        /// 
        public override int getDataSizeInBytes()
        {
            return Size + 5; //+ 5 bytes for header
        }

        /// <summary>
        /// Begins writing of the packet data to the given Stream.
        /// </summary>
        /// <param name="outStream">The stream to write the packet data to.</param>
        public override void writePacketData(System.IO.Stream outStream)
        {
            //write the FRAME TYPE 
            if (writeKeyFrame)
            {
                outStream.WriteByte(KEY_FRAME | CODEC_ID_SCREEN);

            }
            else
            {
                outStream.WriteByte(INTER_FRAME | CODEC_ID_SCREEN);
            }
            int dimension = 0;

            dimension |= (BlockWidth << 28);
            dimension |= (ImageWidth << 16);
            dimension |= (BlockHeight << 12);
            dimension |= ImageHeight;

            outStream.WriteByte((byte)(dimension >> 24));
            outStream.WriteByte((byte)(dimension >> 16));
            outStream.WriteByte((byte)(dimension >> 8));
            outStream.WriteByte((byte)(dimension));

            //calculate how many horizontal blocks there are
            byte hBlocks = (byte)(ImageHeight / ((BlockHeight + 1) * 16));

            //calculate how many vertical blocks there are
            byte wBlocks = (byte)(ImageWidth / ((BlockWidth + 1) * 16));

            //determine the remainder (non evenly divisible blocks)
            byte widthRemainder = (byte)(ImageWidth % ((BlockWidth + 1) * 16) == 0 ? 0 : 1);
            byte heightRemainder = (byte)(ImageHeight % ((BlockHeight + 1) * 16) == 0 ? 0 : 1);

            //calculate the number of rows
            int rows = hBlocks + heightRemainder;

            //calculate the number of cols
            int cols = wBlocks + widthRemainder;

            //calculate how many blocks in total
            int n = ((hBlocks + heightRemainder) * (wBlocks + widthRemainder));

            int rw = 0, rh = 0;

            if (widthRemainder >= 1)
            {
                rw = ImageWidth - (((cols - 1) * ((BlockWidth + 1) * 16)));
            }

            if (heightRemainder >= 1)
            {
                rh = ImageHeight - ((rows - 1) * ((BlockHeight + 1) * 16));
            }

            //loop through N blocks and write their data
            for (int i = 1; i <= n; i++)
            {

                long streami = outStream.Position;

                //place holder
                outStream.WriteByte(0);
                outStream.WriteByte(0);
                int srcLength = 0;
                //write the block's data

                if (!writeKeyFrame)
                {
                    srcLength = writeBlock(outStream, i, n, cols, rows, cols, rw * bpp, rh * bpp, (BlockWidth + 1) * 16 * bpp, (BlockHeight + 1) * 16 * bpp);

                }
                else
                {
                    srcLength = writeKeyBlock(outStream, i, n, cols, rows, cols, rw * bpp, rh * bpp, (BlockWidth + 1) * 16 * bpp, (BlockHeight + 1) * 16 * bpp);
                    dirty_block = true;
                }

                //calculate the length buffer
                int length = (int)((BlockWidth + 1) * 16 * (BlockHeight + 1) * 16 * 3 * 1.001 + 12);

                //compress the block and write it's data ONLY if it is dirty
                if (dirty_block)
                {
                    //make this a dirty frame
                    this.frame_dirty = true;

                    //compress the block
                    compress2(destBuff, ref length, srcBuff, srcLength, compressionLevel);

                    //write the compressed data
                    outStream.Write(destBuff, 0, length);

                    //write back and write the block length
                    long streamc = outStream.Position;
                    outStream.Seek(streami, SeekOrigin.Begin);

                    //record the size
                    this.Size += length;

                    //write the size of this block
                    outStream.WriteByte((byte)((length & 0xFF00) >> 8));
                    outStream.WriteByte((byte)(length & 0x00FF));

                    //seek back to current end of stream position
                    outStream.Seek(streamc, SeekOrigin.Begin);
                }
                this.Size += 2;



            }


        }

        /// <summary>
        /// Constructor the video packet.
        /// </summary>
        /// <param name="newFrame">The byte array for the pixel data for the new frame.</param>
        /// <param name="previousFrame">The byte array for the pixel data from the PREVIOUS frame.</param>
        /// <param name="height">The width of the image, in pixels.</param>
        /// <param name="width">The height of the image, in pixels.</param>
        public FLVScreenVideoPacket(byte[] newFrame, byte[] previousFrame, ushort width, ushort height, byte[] src, byte[] dest, bool key, int comp,
            byte bpp)
        {

            this.ImageHeight = height;
            this.ImageWidth = width;
            this.currentFrame = newFrame;
            this.previousFrame = previousFrame;
            this.srcBuff = src;
            this.destBuff = dest;
            this.writeKeyFrame = key;
            this.compressionLevel = comp;
            this.frame_dirty = false;
            this.bpp = bpp;


        }



        /// <summary>
        /// This is where all the 'logic' occurs. This method compares it's own block
        /// with the block in the previous frame to determine if any information is to
        /// be written. If information is required, the byte array for the block is compressed
        /// using zlib.
        /// </summary>
        /// <param name="outStream">The stream to write the resultant block data to.</param>
        /// <param name="n">The block ID to work with.</param>
        private int writeBlock(Stream outStream, int n, int numBlocks, int blocksPerRow, int rows, int cols, int wr, int hr,
            int bw, int bh)
        {
            //assume from default this block is not dirty
            dirty_block = false;

            int rowNum = (n / cols);

            double s = (n / cols);
            if (n % cols != 0)
            {
                s++;
                rowNum = (int)s;
            }

            int rowLengthInPixels = ImageWidth * bpp;

            int reverseBlock = numBlocks - (n - 1);

            int rrowNum = (reverseBlock / cols);

            s = (reverseBlock / cols);
            if (reverseBlock % cols != 0)
            {
                rrowNum++;
            }

            reverseBlock = (rrowNum * blocksPerRow) - (reverseBlock - 1) + (((rrowNum) * blocksPerRow - (blocksPerRow - 1)) - 1);

            int startIndex = 0;

            int blockInRow = reverseBlock - ((rrowNum - 1) * blocksPerRow);

            startIndex = ((rrowNum - 1) * (bh / bpp) * rowLengthInPixels);

            startIndex += (blockInRow - 1) * bw;

            if (hr > 0 && rrowNum > 1)
            {
                startIndex -= (bh / bpp) * rowLengthInPixels;
                startIndex += (hr / bpp) * rowLengthInPixels;
            }

            int rBlockWidth = 0;

            if (n % cols == 0 && wr > 0)
            {
                //determine if this block lies on the edge of grid
                //and if so, assign its true block width to the calculated
                //remainder
                rBlockWidth = wr;
            }
            else
            {
                rBlockWidth = bw;
            }

            int rBlockHeight = 0;

            if ((rowNum) == rows && hr > 0)
            {
                //this block is at the "top" of the grid thus may not
                //contain a full block height, so assign it the height
                //remainder
                rBlockHeight = hr;
            }
            else
            {
                rBlockHeight = bh;
            }

            //reset the length of the srcBlockBuffer
            int srcBuffLength = 0;

            int condition = startIndex;

            //move forward one full block row in the array data
            //and encode backwards. (since flv requires bottom-up pixel
            //information.
            startIndex += ((rBlockHeight / bpp) - 1) * rowLengthInPixels;

            //loop through and compare each pixel colour ( there has to be a faster way)
            for (int i = startIndex; i >= condition; i -= rowLengthInPixels)
            {

                for (int j = i; j < i + rBlockWidth; j += bpp)
                {
                    if (currentFrame[j] != previousFrame[j])
                    {
                        dirty_block = true;
                        break;
                    }
                    else if (currentFrame[j + 1] != previousFrame[j + 1])
                    {
                        dirty_block = true;
                        break;
                    }
                    else if (currentFrame[j + 2] != previousFrame[j + 2])
                    {
                        dirty_block = true;
                        break;
                    }

                }

            }
            //if its not dirty , go back
            if (!dirty_block)
                return 0;

            //copy since it's dirty :)
            for (int i = startIndex; i >= condition; i -= rowLengthInPixels)
            {

                for (int j = i; j < i + rBlockWidth; j += bpp)
                {

                    srcBuff[srcBuffLength] = currentFrame[j];
                    srcBuff[srcBuffLength + 1] = currentFrame[j + 1];
                    srcBuff[srcBuffLength + 2] = currentFrame[j + 2];
                    srcBuffLength += 3; //increment the length of the srcBlockBuffer

                }

            }

            return srcBuffLength;
        }

        /// <summary>
        /// This is where all the 'logic' occurs. This method compares it's own block
        /// with the block in the previous frame to determine if any information is to
        /// be written. If information is required, the byte array for the block is compressed
        /// using zlib.
        /// </summary>
        /// <param name="outStream">The stream to write the resultant block data to.</param>
        /// <param name="n">The block ID to work with.</param>
        private int writeKeyBlock(Stream outStream, int n, int numBlocks, int blocksPerRow, int rows, int cols, int wr, int hr,
            int bw, int bh)
        {

            int rowNum = (n / cols);

            double s = (n / cols);
            if (n % cols != 0)
            {
                s++;
                rowNum = (int)s;
            }


            int rowLengthInPixels = ImageWidth * bpp;

            int reverseBlock = numBlocks - (n - 1);

            int rrowNum = (reverseBlock / cols);

            s = (reverseBlock / cols);
            if (reverseBlock % cols != 0)
            {
                rrowNum++;
            }

            reverseBlock = (rrowNum * blocksPerRow) - (reverseBlock - 1) + (((rrowNum) * blocksPerRow - (blocksPerRow - 1)) - 1);



            int startIndex = 0;

            int blockInRow = reverseBlock - ((rrowNum - 1) * blocksPerRow);

            startIndex = ((rrowNum - 1) * (bh / bpp) * rowLengthInPixels);

            startIndex += (blockInRow - 1) * bw;

            if (hr > 0 && rrowNum > 1)
            {
                startIndex -= (bh / bpp) * rowLengthInPixels;
                startIndex += (hr / bpp) * rowLengthInPixels;
            }

            int rBlockWidth = 0;

            if (n % cols == 0 && wr > 0)
            {
                //determine if this block lies on the edge of grid
                //and if so, assign its true block width to the calculated
                //remainder
                rBlockWidth = wr;
            }
            else
            {
                rBlockWidth = bw;
            }

            int rBlockHeight = 0;

            if ((rowNum) == rows && hr > 0)
            {
                //this block is at the "top" of the grid thus may not
                //contain a full block height, so assign it the height
                //remainder
                rBlockHeight = hr;
            }
            else
            {
                rBlockHeight = bh;
            }

            //reset the length of the srcBlockBuffer
            int srcBuffLength = 0;

            int condition = startIndex;

            //move forward one full block row in the array data
            //and encode backwards. (since flv requires bottom-up pixel
            //information.
            startIndex += ((rBlockHeight / bpp) - 1) * rowLengthInPixels;

            for (int i = startIndex; i >= condition; i -= rowLengthInPixels)
            {

                for (int j = i; j < i + rBlockWidth; j += bpp)
                {
                    //copy 3 bytes from the frame data
                    //skip ahead four bytes because of the BPP depth
                    //of windows. (This will need to be changed later to support
                    //users using a display resolution of 24bpp).
                    srcBuff[srcBuffLength] = currentFrame[j];
                    srcBuff[srcBuffLength + 1] = currentFrame[j + 1];
                    srcBuff[srcBuffLength + 2] = currentFrame[j + 2];
                    srcBuffLength += 3; //increment the length of the srcBlockBuffer

                }
            }

            return srcBuffLength;
        }


        /// <summary>
        /// Determines if any dirty blocks hvae been encoded. That is, has any information
        /// since the previous frame been changed.
        /// </summary>
        /// <returns>True if there was at least *one* dirty block. False otherwise.</returns>
        public override bool isFrameDirty()
        {
            return frame_dirty;
        }



    }
}
