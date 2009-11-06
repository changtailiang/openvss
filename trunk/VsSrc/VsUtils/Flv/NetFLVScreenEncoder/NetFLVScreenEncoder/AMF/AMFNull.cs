using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NetFLVScreenEncoder.AMF
{
    class AMFNull : AMFDataType
    {

        public override byte getType()
        {
            return AMF_NULL;
        }

        public override void setData(object data)
        {
            // do nothing;
        }

        public AMFNull()
        {
        }


        public override void write(Stream outStream)
        {
            outStream.WriteByte(this.getType()); //write null format



        }

        public override string ToString()
        {
            return "AMF_NULL";
        }

        public override void read(Stream inStream)
        {

            return;
            //nothing to read, the type
        }

    }
}
