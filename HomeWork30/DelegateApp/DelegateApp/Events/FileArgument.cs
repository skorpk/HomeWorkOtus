namespace DelegateApp
{
    public class FileArgs : EventArgs
    {
        public string FileName { get; }
        
        public bool CancelRequested { get; set; }

        public FileArgs(string fileName)
        {
            FileName = fileName;
            CancelRequested = false; // По умолчанию не производим отмену
        }
    }
}