using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NetFLVScreenEncoder
{
    /// <summary>
    /// Encapsulates the header at the beginning of an FLV file. For the most part this is a static class
    /// and no information in it can be changed by a program calling the library. The header is only used when
    /// writing FLV information to file.
    /// </summary>
    public class FLVHeader
    {

        private static byte SIGNATURE_1 = 0x46; //F - 1 byte

        private static byte SIGNATURE_2 = 0x4C; //L - 1 byte

        private static byte SIGNATURE_3 = 0x56; //V - 1 byte

        private static byte VERSION = 0x01; //FLV Version Number 1 byte

        //The following header values are to be compressed, at file write time
        //into one byte, given that each of these values is to be stored into
        //a single byte.
        //--------------------------------------------------------------------

        private static byte TYPE_FLAGS_RESERVED_1 = 0; //5 bits (Must be 0)

        private static byte TYPE_FLAGS_AUDIO = 0; //1bit (0) No Audio

        private static byte TYPE_FLAGS_RESERVED_2 = 0; //1 bit (Must be 0)

        private static byte TYPE_FLAGS_VIDEO = 1; //1 bit (video so (1))

        //--------------------------------------------------------------------

        // size of header data (including offset) to start of body
        private static int OFFSET = 0x9; //3 bytes
        //thus 1 + 1 + 1 + 1 + 3 + 1 = 9 bytes (and this is the size of the header offset)

        /// <summary>
        /// Writes the header information to the given Stream.
        /// </summary>
        /// <param name="stream">The Stream the header is to be written to.</param>
        public static void WriteHeader(Stream stream)
        {
            if (!stream.CanWrite)
            {
                throw new IOException("Given stream is not suitable for writing.");
            }

            stream.WriteByte(FLVHeader.SIGNATURE_1);
            stream.WriteByte(FLVHeader.SIGNATURE_2);
            stream.WriteByte(FLVHeader.SIGNATURE_3);
            stream.WriteByte(FLVHeader.VERSION);

            //now create the next byte using the given bits
            //it is an int to stop nagging from compiler
            int headerBitFlags = 0;

            headerBitFlags = headerBitFlags | FLVHeader.TYPE_FLAGS_RESERVED_1 << 3;
            headerBitFlags = headerBitFlags | FLVHeader.TYPE_FLAGS_AUDIO << 2;
            headerBitFlags = headerBitFlags | FLVHeader.TYPE_FLAGS_RESERVED_2 << 1;
            headerBitFlags = headerBitFlags | FLVHeader.TYPE_FLAGS_VIDEO;

            stream.WriteByte((byte)headerBitFlags);
            stream.WriteByte(0);
            stream.WriteByte(0);
            stream.WriteByte(0);
            stream.WriteByte((byte)FLVHeader.OFFSET);//safe for now*
            


        }


    }
}
