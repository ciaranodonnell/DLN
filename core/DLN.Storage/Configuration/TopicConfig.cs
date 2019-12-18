using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Core.Configuration
{
    public class TopicConfig 
    {

        public enum SegmentRollReasons { None, TimeInMilliseconds, MessageCount};

        public SegmentRollReasons SegmentRollReason { get; set; }

        public int SegmentRollNumber { get; set; }


        public int PrimaryBrokerId { get; set; }
        public int PartitionCount { get; internal set; }
    }
}
