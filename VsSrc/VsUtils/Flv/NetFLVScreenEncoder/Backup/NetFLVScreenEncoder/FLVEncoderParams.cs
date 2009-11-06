namespace NetFLVScreenEncoder
{
    /// <summary>
    /// Parameter class to control all output options used by the library.
    /// </summary>
    public class FLVEncoderParams
    {

        public FLVEncoderParams()
        {
            stream_params = new FLVStreamingParams();
            file_params = new FLVFileParams();
        }

        private int videoHeight;

        private int videoWidth;

        private int frequency = 20;

        private int zlib_compression = 5;

        private byte srcBpp = 4;

        private FLVStreamingParams stream_params;

        private FLVFileParams file_params;

        /// <summary>
        /// Controls the live stream outut specific parameters.
        /// </summary>
        public FLVStreamingParams StreamingParams
        {
            get
            {
                return stream_params;
            }
            set
            {
                stream_params = value;
            }
        }

        /// <summary>
        /// Controls the File output specific paremeters.
        /// </summary>
        public FLVFileParams FileParams
        {
            get
            {
                return file_params;
            }
            set
            {
                file_params = value;
            }
        }


        /// <summary>
        /// Set the height dimension of the video to be encoded.
        /// </summary>
        public int VideoHeight
        {
            get
            {
                return videoHeight;
            }
            set
            {
                videoHeight = value;
            }
        }

        /// <summary>
        /// Set the width dimension of the video to be encoded.
        /// </summary>
        public int VideoWidth
        {
            get
            {
                return videoWidth;
            }
            set
            {
                videoWidth = value;
            }
        }

        /// <summary>
        /// Sets the frequency that key frames are encoded into the video,
        /// in seconds. If 0, the default value is used (once every 20 seconds).
        /// </summary>
        public int KeyFrameFrequency
        {
            get
            {
                return frequency;
            }
            set
            {
                if (value > 0)
                    frequency = value;
                else
                    frequency = 20;
            }
        }

        /// <summary>
        /// Sets the compression level of the frame data. Although the codec
        /// is lossless, a higher compression will yield a smaller file
        /// size but require longer encoding time.
        /// </summary>
        public int CompressionLevel
        {
            get
            {
                return zlib_compression;
            }
            set
            {
                zlib_compression = value;
            }
        }

        /// <summary>
        /// Set the source bytes per pixel.
        /// For example a SourceBytesPerPixel of 4 means
        /// that there is 4 bytes used to represent the pixel.
        /// r,g,b,a. Alpha is ignored in the encoding process,
        /// but depending on the display colour depth, alpha
        /// params may be "captured" from the screen capture method.
        /// 
        /// Use this property to override if the display depth is 
        /// only 24bit and tell the encoder that there is no alpha channel.
        /// 
        /// Default: 4.
        /// </summary>
        public byte SourceBytesPerPixel
        {
            get
            {
                return srcBpp;
            }
            set
            {
                if (value != 3 && value != 4)
                    srcBpp = 4;
                else
                    srcBpp = value;
            }
        }
    }

    /// <summary>
    /// Handles all output options that the library uses to write to file.
    /// </summary>
    public class FLVFileParams
    {
        private string file_name;

        /// <summary>
        /// The path of the file that the video will be output to.
        /// </summary>
        public string FilePath
        {
            get
            {
                return file_name;
            }
            set
            {
                file_name = value;
            }
        }
    }

    /// <summary>
    /// Handles all RTMP options that the library uses to connect to a media server.
    /// </summary>
    public class FLVStreamingParams
    {
        private string server_url;

        private string swf_url;

        private int port;

        private string stream_name;

        private string publish_name;

        private string app_name;

        private string protocol = RTMP;

        public const string RTMP = "rtmp";

        public const string RTMPT = "rtmpt";

        public string Protocol
        {
            get
            {
                return protocol;
            }
            set
            {
                protocol = value;
            }
        }

        private bool record_on_server = false;
        /// <summary>
        /// The name of the application to connect to on the media server.
        /// </summary>
        public string ApplicationName
        {
            get
            {
                return app_name;
            }
            set
            {
                app_name = value;
            }
        }

        /// <summary>
        /// The publish name to create for the video stream.
        /// </summary>
        public string PublishName
        {
            get
            {
                return publish_name;
            }
            set
            {
                publish_name = value;
            }
        
        }

        /// <summary>
        /// The URL of the server without any protocol prefix.
        /// Ie: "127.0.0.1"
        /// </summary>
        public string ServerURL
        {
            get
            {
                return server_url;
            }
            set
            {
                server_url = value;
            }
        }

        /// <summary>
        /// The location of the SWF file. (Optional)
        /// </summary>
        public string SWFUrl
        {
            get
            {
                return swf_url;
            }
            set
            {
                swf_url = value;
            }
        }

        /// <summary>
        /// The port to connect to on the media server.
        /// </summary>
        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        /// <summary>
        /// The stream name. Optional.
        /// </summary>
        public string StreamName
        {
            get
            {
                return stream_name;
            }
            set
            {
                stream_name = value;
            }
        }

        /// <summary>
        /// Tells the media server whether or not the video stream should be recorded.
        /// </summary>
        public bool Record
        {
            get
            {
                return record_on_server;
            }
            set
            {
                record_on_server = value;
            }
        }


    }
}