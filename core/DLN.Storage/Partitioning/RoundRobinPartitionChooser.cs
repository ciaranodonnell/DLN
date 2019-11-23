using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Core.Partitioning
{
    public class RoundRobinPartitionChooser : IPartitionChooser
    {
        private int numPartitions;
        private int lastPartition;

        public RoundRobinPartitionChooser(int numberPartitions)
        {
            this.numPartitions = numberPartitions;
            this.lastPartition = -1;
        }

        public int WhatPartition(string partitionKey)
        {
            return (lastPartition = ((++lastPartition) % numPartitions));
        }


    }
}
