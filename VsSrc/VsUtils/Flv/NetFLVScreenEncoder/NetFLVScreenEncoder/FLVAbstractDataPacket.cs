using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NetFLVScreenEncoder
{
    internal abstract class FLVAbstractDataPacket
    {
        public abstract int getDataSizeInBytes();

        public abstract void writePacketData(Stream outStream);

        public abstract bool isFrameDirty();
    }
}
