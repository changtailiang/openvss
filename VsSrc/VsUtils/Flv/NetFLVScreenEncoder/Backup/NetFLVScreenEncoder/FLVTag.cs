using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NetFLVScreenEncoder
{
    internal class FLVTag
    {
        public const byte TAGTYPE_AUDIO = 8;
        
        public const byte TAGTYPE_VIDEO = 9;
        
        public const byte TAGTYPE_SCRIPT_DATA = 18;


        private byte TagType;

        /// <summary>
        /// Time in milliseconds at which the data in this tag applies.
        /// This is relative to the first tag in the FLV file, which always
        /// has a time stamp of 0.
        /// </summary>
        public int TimeStamp;


        /// <summary>
        /// An Abstract data packet that contains the data for this tag.
        /// Each tag is responsible for writing its own info to the stream.
        /// </summary>
        private FLVAbstractDataPacket DataPacket;




        public FLVTag(byte tagType,byte[] frame, byte[] previousFrame, int timeStamp, int width, int height,byte[]src,byte[]dest,
            bool key, int comp, byte bpp)
        {
            this.TagType = tagType;

            this.TimeStamp = timeStamp;

            switch (tagType)
            {
                case TAGTYPE_VIDEO:
                    DataPacket = new FLVScreenVideoPacket(frame,previousFrame,(ushort)width,(ushort)height,src,dest,key,comp,bpp);
                    break;
            }
        }

        public int getTagSizeInBytes()
        {
            return DataPacket.getDataSizeInBytes() + 11;
        }

        public bool isFrameDirty()
        {
            return DataPacket.isFrameDirty();
        }

        public void writeTag(Stream output)
        {
            //write teh TAG Type, which is a video tag.
            output.WriteByte(TAGTYPE_VIDEO);

            //now write the size of the data in this tag.
            //use 3 place holder 0's because this will be
            //seeked to later when we can figure out the actual
            //size
            long sizePos = output.Position;
            output.WriteByte(0);
            output.WriteByte(0);
            output.WriteByte(0);


            //write the lower 24 bits first
            output.WriteByte((byte)(TimeStamp >> 16));
            output.WriteByte((byte)(TimeStamp >> 8));
            output.WriteByte((byte)(TimeStamp));
            output.WriteByte((byte)(TimeStamp >> 24));
     

            //write the stream id which is always 0
            // (3 bytes)
            output.WriteByte(0);
            output.WriteByte(0);
            output.WriteByte(0);

            //now write the video packet data
            DataPacket.writePacketData(output);

            //now that the size has been calculated seek back and write the size

            int size = DataPacket.getDataSizeInBytes();
            long end = output.Position;
            output.Seek(sizePos, SeekOrigin.Begin);
            output.WriteByte((byte)(size >> 16));
            output.WriteByte((byte)(size >> 8));
            output.WriteByte((byte)(size));
            output.Seek(end,SeekOrigin.Begin);

        }




    }
}
