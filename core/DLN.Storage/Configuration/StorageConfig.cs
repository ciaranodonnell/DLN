namespace DLN.Core.Configuration
{
    public class StorageConfig
    {


        public string StorageFolderPath { get; set; }
        public string TopicsFolder
        {
            get => System.IO.Path.Combine(StorageFolderPath + "topics");
        }
    }
}