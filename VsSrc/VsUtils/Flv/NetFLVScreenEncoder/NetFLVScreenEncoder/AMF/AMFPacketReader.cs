using System;
using System.Collections.Generic;
using System.Text;

namespace NetFLVScreenEncoder.AMF
{
    class AMFPacketReader
    {

        LinkedList<AMFDataType> parameters;
        public AMFPacketReader()
        {

        }

        /// <summary>
        /// Instructs the AMFPacketReader to decode the information contained
        /// within the byte array given.
        /// </summary>
        /// <param name="data">The packet data to decode.</param>
        /// <param name="l">The size (in bytes) of the actual packet data contained
        /// within the data array.</param>
        public static void readPacketData(byte[] data, int l)
        {

        }

        /// <summary>
        /// Return the value of a given return value in the array.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AMFDataType this[string name]
        {
            get
            {
                return new AMFString("");
            }
            set
            {

            }
        }
    }
}
