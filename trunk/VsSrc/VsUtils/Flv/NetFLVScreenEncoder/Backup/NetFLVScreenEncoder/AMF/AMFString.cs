using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NetFLVScreenEncoder.AMF
{
    class AMFString : AMFDataType
    {
        private string data;

        public override byte getType()
        {
            return AMF_STRING;
        }

        public override void setData(object data)
        {
            this.data = (string)data;
        }

        public AMFString(string svalue)
        {
            this.data = svalue;
        }


        public override void write(Stream outStream)
        {
            outStream.WriteByte(this.getType()); //write string format
            short length = (short)data.Length;
            //big endian ..
            outStream.WriteByte((byte)(length >> 8));
            outStream.WriteByte((byte)(length));

            //now write the string
            char[] c_string = data.ToCharArray();

            foreach (char c in c_string)
            {
                outStream.WriteByte((byte)c);
            }


        }

        public override void read(Stream inStream)
        {
            short s = 0;
            s |= (short)(inStream.ReadByte() << 8);
            s |= ((short)inStream.ReadByte());
            for (int i = 0; i < s; i++)
            {
                data += (char)inStream.ReadByte();
            }

        }

        public override string ToString()
        {
            return data;
        }

    }
}
