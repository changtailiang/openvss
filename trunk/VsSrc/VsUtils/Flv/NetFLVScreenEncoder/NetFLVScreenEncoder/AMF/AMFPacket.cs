using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NetFLVScreenEncoder.AMF
{
    class AMFPacket
    {
        /// <summary>
        /// Parses the given packet contained in the byte buffer array and returns
        /// a list of packets
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static LinkedList<AMFDataType> getPacketVars(byte[] buffer, int length, int offset)
        {
            //the linked list of packet vars
            LinkedList<AMFDataType> packetVars = new LinkedList<AMFDataType>();

            //read the header byte to determine size
            MemoryStream packetStream = new MemoryStream(buffer, offset, length);

            byte header = (byte)packetStream.ReadByte();
            header &= 0xC0; // isolate the size information

            //seek into the packet
            packetStream.Seek(AMFHeader.getHeaderSize(header) - 1, SeekOrigin.Current);

            while (packetStream.Position < length)
            {
                byte type = (byte)packetStream.ReadByte();
                Console.WriteLine("Looking at type: " + type);
                AMFDataType var = findAppropriateReader(type);
                var.read(packetStream);
                packetVars.AddLast(var);

            }
            

            return packetVars;

        }

        private static AMFDataType findAppropriateReader(byte type)
        {
            switch (type)
            {
                case AMFDataType.AMF_DOUBLE:
                    return new AMFDouble(0);
                case AMFDataType.AMF_NULL:
                    return new AMFNull();
                case AMFDataType.AMF_OBJECT:
                    return new AMFObject();
                case AMFDataType.AMF_BOOLEAN:
                    return new AMFBoolean(false);
                case AMFDataType.AMF_STRING:
                    return new AMFString("");
            }

            return null;
        }

        
    }
}
