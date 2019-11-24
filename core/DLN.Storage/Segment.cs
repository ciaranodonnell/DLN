using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DLN.Storage
{
    class Segment
    {
        private SegmentIndex index;

        private BinaryWriter writer;

        private BinaryReader reader;


        private Segment()
        {

        }

        internal static Segment LoadFromFile(DirectoryInfo dirInfo, FileInfo file)
        {
            Segment segment = new Segment();

            segment.Directory = dirInfo;

            segment.FirstSequenceNumber = long.Parse(file.Name);

            segment.index = new SegmentIndex(file.FullName);

            segment.OpenFileToWrite(file.FullName);

            return segment;
        }

        public Segment(DirectoryInfo directory, long segmentOffsetNumber)
        {
            Directory = directory;
            FirstSequenceNumber = segmentOffsetNumber;

            var fileName = Path.Combine(directory.FullName, segmentOffsetNumber.ToString("00000000000000000000"));

            this.index = new SegmentIndex(fileName);
            OpenFileToWrite(fileName);
        }

        private void OpenFileToWrite(string fileName)
        {


            var readStream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            this.reader = new BinaryReader(readStream, Encoding.Default, false);


            var segmentFile = File.Open(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            this.writer = new BinaryWriter(segmentFile, Encoding.Default, false);


        }

        public DirectoryInfo Directory { get; private set; }
        public long FirstSequenceNumber { get; private set; }
        public long MaxSequenceNumber { get { return index.MaxSequenceNumber; } }

        internal void WriteMessage(Record pubRequest)
        {

            index.AddMessage(pubRequest.SequenceNumber, this.writer.BaseStream.Position);
            writer.Write(pubRequest.SequenceNumber);
            writer.Write(pubRequest.MessageKey?.Length ?? 0);

            if (pubRequest.MessageKey != null)
                writer.Write(pubRequest.MessageKey);

            writer.Write(pubRequest.PartitionKey.Length);

            if (pubRequest.PartitionKey != null)
                writer.Write(pubRequest.PartitionKey);

            writer.Write(pubRequest.MessageData.Length);

            writer.Write(pubRequest.MessageData);

            writer.Flush();


        }


        internal Record ReadMessage(long sequenceNumber)
        {
            var seekIndex = index.GetLocation(sequenceNumber);

            if (!seekIndex.HasValue)
            {
                //its not in this segment, likely meaning its not in this partition
                return null;
            }

            reader.BaseStream.Seek(seekIndex.Value, SeekOrigin.Begin);

            var message = new Record();

            message.SequenceNumber = reader.ReadInt64();
            var keyLen = reader.ReadInt32();
            if (keyLen > 0) message.MessageKey = reader.ReadString();

            var pkeyLen = reader.ReadInt32();
            if (pkeyLen > 0) message.PartitionKey = reader.ReadString();

            var msgLen = reader.ReadInt32();
            message.MessageData = reader.ReadBytes(msgLen);

            return message;
        }


    }
}
