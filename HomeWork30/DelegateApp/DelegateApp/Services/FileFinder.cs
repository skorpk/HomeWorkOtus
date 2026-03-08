namespace DelegateApp
{
    public class FileFinder
    {
        public event EventHandler<FileArgs> FileFound;

        public void Search(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Каталог {directoryPath} не существует.");
                return;
            }

            SearchInternal(directoryPath);
        }

        //Метод обхода(рекурсивный)
        private bool SearchInternal(string currentDirectory)
        {
            try
            {
                foreach (var file in Directory.EnumerateFiles(currentDirectory))
                {
                    var args = new FileArgs(file);
                    
                    FileFound?.Invoke(this, args);

                    //Проверка. Не запросил ли пользователь подписку
                    if (args.CancelRequested)
                    {
                        return true;
                    }
                }
                
                foreach (var dir in Directory.EnumerateDirectories(currentDirectory))
                {
                    if (SearchInternal(dir))
                    {
                        return true;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }

            return false;
        }
    }
}