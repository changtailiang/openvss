using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace NetFLVScreenEncoder.AMF
{

    class AMFHeader
    {
        public const byte HEADER_12 = 0x0;
        public const byte HEADER_8 = 0x40;
        public const byte HEADER_4 = 0x80;
        public const byte HEADER_1 = 0xC0;

        public const byte RTMP_TYPE_VIDEO = 0x9;
        public const byte RTMP_TYPE_FUNCTION = 0x14;
        public const byte RTMP_TYPE_AUDIO = 0x8;
        public const byte RTMP_TYPE_PING = 0x4;

        private byte headerByte;
        private byte headerType;
        private int endPoint;
        private int timeStamp;
        private byte rtmpType;
        private int bodySize;
        private byte channelId;

        public int getHeaderSize()
        {
            switch (headerType)
            {
                case HEADER_1:
                    return 1;
                case HEADER_4:
                    return 4;
                case HEADER_8:
                    return 8;
                case HEADER_12:
                    return 12;
                default:
                    return 0;

            }
        }

        public static int getHeaderSize(byte headerBits)
        {
            switch (headerBits)
            {
                case HEADER_1:
                    return 1;
                case HEADER_4:
                    return 4;
                case HEADER_8:
                    return 8;
                case HEADER_12:
                    return 12;
                default:
                    return 0;

            }
        }

        /// <summary>
        /// Sets the EndPoint (index) of this AMF message.
        /// </summary>
        public int EndPoint
        {
            get
            {
                return this.endPoint;
            }
            set
            {
                this.endPoint = value;
            }
        }

        /// <summary>
        /// Sets the packet type.
        /// Use one of RTMP_TYPE_VIDEO  or RTMP_TYPE_FUNCTION
        /// </summary>
        public byte RTMPType
        {
            get
            {
                return this.rtmpType;
            }
            set
            {
                this.rtmpType = value;
            }
        }

        /// <summary>
        /// Sets the time stamp ( applicable for audio / video tags).
        /// </summary>
        public int TimeStamp
        {
            get
            {
                return this.timeStamp;
            }
            set
            {
                this.timeStamp = value;
            }
        }

        /// <summary>
        /// Sets the size (in bytes) of the  AMF actual data.
        /// </summary>
        public int BodySize
        {
            get
            {
                return this.bodySize;
            }
            set
            {
                this.bodySize = value;
            }
        }

        public byte get_1_HeaderByte()
        {
            return (byte)(HEADER_1 | this.channelId);
        }

        public byte ChannelId
        {
            get
            {
                return this.channelId;
            }
            set
            {
                this.channelId = value;
            }
        }

        public byte HeaderTypeSize
        {
            get
            {
                return this.headerType;
            }
            set
            {
                this.headerType = value;
            }
        }


        /// <summary>
        /// Initializes a new AMFHeader
        /// </summary>
        /// <param name="headerType">The header type either 12,8,4 or 1 byte</param>
        /// <param name="channelId">The channel to send the information on</param>
        public AMFHeader(byte headerType, byte channelId)
        {
            this.headerByte = (byte)(headerType | channelId);
            this.headerType = headerType;
            this.channelId = channelId;
        }

        public void writeHeader(Stream output)
        {
            //write the channel ID and header type
            output.WriteByte(headerByte);

            //write the time stamp bytes ( 3 bytes )
            output.WriteByte((byte)(timeStamp >> 16));
            output.WriteByte((byte)(timeStamp >> 8));
            output.WriteByte((byte)(timeStamp));

            //write the size of the body
            output.WriteByte((byte)(bodySize >> 16));
            output.WriteByte((byte)(bodySize >> 8));
            output.WriteByte((byte)(bodySize));

            //write the RTMP Type
            output.WriteByte(rtmpType);

            //write the endpoint bytes ( or stream ID if video )
            output.WriteByte((byte)(endPoint));
            output.WriteByte((byte)(endPoint >> 8));
            output.WriteByte((byte)(endPoint >> 16));
            output.WriteByte((byte)(endPoint >> 24));
        }

        /// <summary>
        /// Reads the header information from the given byte[] data.
        /// </summary>
        /// <param name="offset">The offset in the data buffer to look at</param>
        /// <param name="data">The data to look at</param>
        /// <returns>null if the data is not valid, or an AMFHeader object representing
        /// the information</returns>
        public static AMFHeader readHeader(int offset, byte[] data)
        {
            AMFHeader header = new AMFHeader(0, 0);
            header.ChannelId = (byte)(data[offset] & 0x3F);
            header.HeaderTypeSize = (byte)(data[offset] & 0xC0);
            offset++;
            if (header.getHeaderSize() > 4)
            {
                //read the timestamp portion
                header.TimeStamp |= data[offset] << 16;
                header.TimeStamp |= data[offset + 1] << 8;
                header.TimeStamp |= data[offset + 2];
                offset += 3;

            }

            if (header.getHeaderSize() > 8)
            {
                //read the AMF body size
                header.BodySize |= data[offset] << 16;
                header.BodySize |= data[offset + 1] << 8;
                header.BodySize |= data[offset + 2];
                offset += 3;
            }

            if (header.getHeaderSize() > 8)
            {
                //read the AMF type
                header.RTMPType = data[offset];
                offset++;
            }

            if (header.getHeaderSize() > 12)
            {
                //write the endpoint bytes ( or stream ID if video )
                header.endPoint |= data[offset];
                header.endPoint |= (data[offset + 1] << 8);
                header.endPoint |= (data[offset + 2] << 16);
                header.endPoint |= (data[offset + 3] << 24);

            }

            return header;
        }

    }


}
