using System;
using System.IO;

namespace DLN.Storage
{
    public class Partition
    {

        private string filePath;
        private DirectoryInfo dirInfo;

        

        public Partition(Topic topic, int partitionNumber)
        {

            this.PartitionNumber = partitionNumber;
            this.Log = topic;

            this.filePath = Path.Combine(topic.StorageFolder, partitionNumber.ToString());
            this.dirInfo = new DirectoryInfo(filePath);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            else
            {
                LoadExistingSegments();
            }


        }

        void LoadExistingSegments()
        {
            //TODO: Load the segments that exist already
            //This should give us a complete index of the topic
        }


        public int NextSequenceNumber { get; private set; }
        
        public int PartitionNumber { get; set; }
        public Topic Log { get; }
    }
}
