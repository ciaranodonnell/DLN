using System;
using System.Collections.Generic;
using System.Text;

namespace DLN.Core.Partitioning
{
    public class HashModPartitionCountBasedChooser : IPartitionChooser
    {
        private int partitionCount;

        public HashModPartitionCountBasedChooser(int partitionCount)
        {
            this.partitionCount = partitionCount;
        }

        public int WhatPartition(string partitionKey)
        {
            
            return partitionKey.GetHashCode() % partitionCount;

        }
    }
}
