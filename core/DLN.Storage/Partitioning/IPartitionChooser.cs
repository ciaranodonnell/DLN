namespace DLN.Core.Partitioning
{
    public interface IPartitionChooser
    {
        int WhatPartition(string partitionKey);
    }
}