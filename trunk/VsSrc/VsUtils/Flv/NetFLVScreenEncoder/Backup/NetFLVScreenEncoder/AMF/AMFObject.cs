using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NetFLVScreenEncoder.AMF
{
    class AMFObject : AMFDataType
    {
        private Dictionary<string, AMFDataType> members;

        public void addParameter(string key, AMFDataType param)
        {
            members.Add(key, param);
        }

        public override byte getType()
        {
            return AMF_OBJECT;
        }

        public override void setData(object data)
        {
            //do nothing this shouldnt happen
        }

        public override string ToString()
        {
            return "object";
        }

        public override void read(Stream inStream)
        {
            
            do
            {
                int check = 0;
                check |= inStream.ReadByte() << 16;
                check |= inStream.ReadByte() << 8;
                check |= inStream.ReadByte();
                if (check == 9) //end of object detected ?
                    break;

                //go back
                inStream.Position = inStream.Position - 3;
                short s_length = 0;
                s_length |= (short)(inStream.ReadByte() << 8);
                s_length |= (short)inStream.ReadByte();



            } while (true);

        }

        public override void write(Stream outStream)
        {
            //write object type
            outStream.WriteByte((byte)this.getType());
            foreach (KeyValuePair<string, AMFDataType> param in members)
            {
                //write each key/value pair
                int length = param.Key.Length;
                outStream.WriteByte((byte)(length >> 8));
                outStream.WriteByte((byte)(length));

                char[] c_string = param.Key.ToCharArray();

                foreach (char c in c_string)
                {
                    outStream.WriteByte((byte)c);
                }

                param.Value.write(outStream);
            }

            //write closing bytes
            outStream.WriteByte(0);
            outStream.WriteByte(0);
            outStream.WriteByte(9);
        }

        public AMFObject()
        {
            members = new Dictionary<string, AMFDataType>();
        }



    }
}
