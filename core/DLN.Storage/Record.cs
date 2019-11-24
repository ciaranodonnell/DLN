using System;

namespace DLN.Storage
{
    public class Record
    {

        public string PartitionKey { get; set; }

        public byte[] MessageData { get; set; }

        public DateTimeOffset PublishedAt { get; set; }
        public long SequenceNumber { get; internal set; }
        public string MessageKey { get; internal set; }
    }
}