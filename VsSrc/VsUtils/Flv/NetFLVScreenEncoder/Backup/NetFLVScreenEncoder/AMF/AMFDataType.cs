using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace NetFLVScreenEncoder.AMF
{
    abstract class AMFDataType
    {
        /// <summary>
        /// An AMF Double (AMF type 0)
        /// </summary>
        public const byte AMF_DOUBLE = 0x0;

        /// <summary>
        /// An AMF Boolean (AMF type 1)
        /// </summary>
        public const byte AMF_BOOLEAN = 0x1;

        /// <summary>
        /// An AMF String (AMF type 2)
        /// </summary>
        public const byte AMF_STRING = 0x2;
        public const byte AMF_OBJECT = 0x3;
        public const byte AMF_NULL = 0x5;

        public abstract byte getType();

        public abstract void write(Stream outStream);

        public abstract void read(Stream inStream);

        public abstract void setData(object data);

        public abstract override string ToString();

        public static AMFDataType findDataHandler(object o)
        {
            if (o == null) return new AMFNull();
            Type oType = o.GetType();
            if (oType == typeof(double))
                return new AMFDouble((double)o);
            else if (oType == typeof(string))
                return new AMFString((string)o);
            else if (oType == typeof(bool))
                return new AMFBoolean((bool)o);
            else if (oType == typeof(int))
            {
                return new AMFDouble(0.0 + (int)o);
            }

            else
                return new AMFString(o.ToString());

        }
    }
}
