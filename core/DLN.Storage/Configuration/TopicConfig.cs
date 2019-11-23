using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Core.Configuration
{
    public class TopicConfig 
    {

        public enum SegmentRoleReasons { None, TimeInMilliseconds, MessageCount};

        public SegmentRoleReasons SegmentRoleReason { get; set; }

        public int SegmentRoleNumber { get; set; }

    }
}
