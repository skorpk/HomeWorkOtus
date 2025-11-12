using System.Diagnostics;
using System.IO;

namespace CountWhiteSpaceInFile;

class Program
{
    static async Task Main(string[] args)
    {
        string pathRead = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "Files"));

        var stopWatch = new Stopwatch();
        int totalWhiteSpace = 0; //вынес для проверки очередности запуска методов


        string[] files = GetThreeFilesFromDirectory(pathRead);

        stopWatch.Start();
        if (files.Length > 0)
        {
            totalWhiteSpace = await CountWhiteSpacesInFilesAsync(files);
        }
        stopWatch.Stop();
        Console.WriteLine("Общее количество пробелов: {0}", totalWhiteSpace);
        Console.WriteLine("Время работы метода: {0} мс", stopWatch.ElapsedMilliseconds);

    }
    static string[] GetThreeFilesFromDirectory(string pathRead)
    {
        if (string.IsNullOrEmpty(pathRead) || !Directory.Exists(pathRead))
        {
            Console.WriteLine("Отсутствет папка для чтения");
            return Array.Empty<string>();
        }

        // Одно перечисление, без предварительного Count()
        var files = Directory.EnumerateFiles(pathRead, "*.txt")
                             .Take(3)
                             .ToArray();

        if (files.Length == 0)
        {
            Console.WriteLine("Отсутствет необходимые файлы для чтения");
            return Array.Empty<string>();
        }

        return files;
    }

    static async Task<int> CountWhiteSpacesInFilesAsync(string[] files)
    {

        /*создаю задачи для каждого найденного файла*/
        var tasks = files.Select(async file =>
        {
            /*читаю каждый файл асинхронно*/
            string content = await File.ReadAllTextAsync(file);
            int whiteSpaceCount = content.Count(x => x == ' ');
            return whiteSpaceCount;
        });
        /*все задачи выполняю синхронно и жду когда выполняться все*/
        int[] results = await Task.WhenAll(tasks);

        return results.Sum();
    }

}