using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DLN.Storage
{
    [StructLayout(LayoutKind.Sequential)]
    class MessageHeader
    {

        public long SequenceNumber;
        public long Position;
        public long CreateTime;
        public int KeySize;
        public int ValueSize;
        public string Key;

    }
}
