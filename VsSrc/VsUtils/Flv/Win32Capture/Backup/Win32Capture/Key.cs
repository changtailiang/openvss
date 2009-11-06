using System;
using System.Collections.Generic;
using System.Text;

namespace Win32Capture
{

    class Key
    {
        public const int VK_CONTROL = 162;
        public const int VK_SHIFT = 0x10;
        public const int VK_SNAPSHOT = 44;
        public const int VK_ALT = 164;

        public int key = 0;

        public Key(int id)
        {
            this.key = id;
        }
    }


}
