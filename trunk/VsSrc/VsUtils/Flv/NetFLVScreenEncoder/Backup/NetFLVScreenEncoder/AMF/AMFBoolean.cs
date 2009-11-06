using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NetFLVScreenEncoder.AMF
{

    class AMFBoolean : AMFDataType
    {
        private bool data;

        public override byte getType()
        {
            return AMF_BOOLEAN;
        }

        public override void setData(object data)
        {
            this.data = (bool)data;
        }

        public AMFBoolean(bool svalue)
        {
            this.data = svalue;
        }

        public override string ToString()
        {
            return "" + data;
        }

        public override void write(Stream outStream)
        {
            outStream.WriteByte(this.getType()); //boolean type

            if (data)
            {
                outStream.WriteByte(1);
            }
            else
            {
                outStream.WriteByte(0);
            }


        }

        public override void read(Stream inStream)
        {
            byte info = (byte)inStream.ReadByte();

            if (info == 1)
                this.data = true;
            else
                this.data = false;

        }

    }

}
