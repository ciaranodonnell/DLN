using System;
using System.Collections.Generic;
using System.IO;

namespace DLN.Storage
{
    public class Partition
    {

        private string filePath;
        private DirectoryInfo dirInfo;
        private Segment currentSegment;
        private List<Segment> segments = new List<Segment>();
        private long maxSequenceNumber;
        private readonly string segmentFileFilter = "*.";

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

        public long MaxSequenceNumber { get { return maxSequenceNumber; } }

        public void Produce(Record pubRequest)
        {
            if (currentSegment == null)
            {
                currentSegment = new Segment(this.dirInfo, pubRequest.SequenceNumber);
                segments.Add(currentSegment);
            }

            currentSegment.WriteMessage(pubRequest);

            this.maxSequenceNumber = pubRequest.SequenceNumber;

            CheckForSegmentClosing();
        }

        internal void CheckForSegmentClosing()
        {
            //This method will close out a segment as needed
        }

        void LoadExistingSegments()
        {
            //TODO: Load the segments that exist already
            //This should give us a complete index of the topic

            var files = dirInfo.GetFiles(segmentFileFilter);

            Array.Sort(files, new Comparison<FileInfo>((t1, t2) => t1.Name.CompareTo(t2.Name)));

            foreach (var file in files)
            {
                var segment = Segment.LoadFromFile(dirInfo, file);
                segments.Add(segment);


            }

            if (segments.Count > 0)
                currentSegment = segments[segments.Count - 1];

            this.maxSequenceNumber = currentSegment?.MaxSequenceNumber ?? 0;

            CheckForSegmentClosing();
        }

        internal Record Consume(long sequenceNumber)
        {
            Segment targetSegment=null;
            foreach(var segment in segments)
            {
                if (segment.FirstSequenceNumber <= sequenceNumber)
                    targetSegment = segment;
                else
                    break;
            }
            
            return targetSegment?.ReadMessage(sequenceNumber);

        }

        public int NextSequenceNumber { get; private set; }

        public int PartitionNumber { get; set; }
        public Topic Log { get; }
    }
}
