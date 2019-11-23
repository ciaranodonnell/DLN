using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Storage
{
    class Message
    {

        public byte[] Data { get; set; }

        public string PartitionKey { get; set; }

        public long Offset { get; set; }
    }
}
