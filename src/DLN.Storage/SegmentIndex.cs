using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DLN.Storage
{
    class SegmentIndex : IDisposable
    {


        Dictionary<long, long> cache = new Dictionary<long, long>();
        private BinaryWriter indexWriter;
        private bool instantFlushToDisk = true;


        public SegmentIndex(string segmentFile)
        {
            FileStream indexFile;
            FileInfo indexFileInfo = new FileInfo(segmentFile + ".index");
            if (indexFileInfo.Exists)
            {
                LoadIndexFromFile(indexFileInfo);
            }
            indexFile = File.Open(indexFileInfo.FullName, FileMode.Append, FileAccess.Write, FileShare.Read);
            indexWriter = new BinaryWriter(indexFile, Encoding.Default, false);


        }

        private void LoadIndexFromFile(FileInfo indexFileInfo)
        {
            using (var existingIndex = File.Open(indexFileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new BinaryReader(existingIndex))
            {
                while(existingIndex.Position < existingIndex.Length)
                    cache.Add(reader.ReadInt64(), reader.ReadInt64());
            }
        }

        public void AddMessage(long sequenceNumber, long offset)
        {
            //TODO: Need to Decide what to do if we write the sequenceNumber and not the offset
            cache.Add(sequenceNumber, offset);
            indexWriter.Write(sequenceNumber);
            indexWriter.Write(offset);

            if (instantFlushToDisk)
                indexWriter.Flush();

        }


        bool isDisposed = false;
        public void Dispose()
        {
            if(!isDisposed)
                indexWriter.Dispose();
        }

    }
}
