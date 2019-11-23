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

        public Segment(DirectoryInfo directory, int segmentOffsetNumber)
        {
            Directory = directory;
            FirstSequenceNumber = segmentOffsetNumber;

            var fileName = Path.Combine(directory.FullName, segmentOffsetNumber.ToString("00000000000000000000"));

            this.index = new SegmentIndex(fileName);

            var segmentFile = File.Open(fileName, FileMode.Append, FileAccess.Write);
            this.writer = new BinaryWriter(segmentFile, Encoding.Default, false);
        }

        public DirectoryInfo Directory { get; }
        public int FirstSequenceNumber { get; }
    }
}
