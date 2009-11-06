using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NetFLVScreenEncoder.AMF
{
    class AMFDouble : AMFDataType
    {
        double data;
        public override byte getType()
        {
            return AMFObject.AMF_DOUBLE;
        }

        public override void setData(object data)
        {
            this.data = (double)data;
        }

        public override string ToString()
        {
            return "" + data;
        }

        public override void read(System.IO.Stream inStream)
        {
            byte[] doubleBytes = new byte[8];
            inStream.Read(doubleBytes, 0, 8);
            Array.Reverse(doubleBytes);
            MemoryStream ms = new MemoryStream(doubleBytes);
            BinaryReader b = new BinaryReader(ms);
            b.ReadDouble();




        }

        public override void write(System.IO.Stream outStream)
        {
            
        }

        public AMFDouble(double value)
        {
            this.data = value;
        }
    }
} 