namespace DelegateApp
{
    class Program
    {
        static void Main()
        {
            /*Задание 1. Обобщенная функция поиска максимума*/
            Console.WriteLine("=========== Проверка GetMax ===========");

            var employees = new List<Employee>
            {
                new Employee { Name = "Работник1", Salary = 50000 },
                new Employee { Name = "Работник2", Salary = 120000 },
                new Employee { Name = "Работник3", Salary = 75000 }
            };

            var richestEmployee = employees.GetMax(e => e.Salary);

            if (richestEmployee != null)
            {
                Console.WriteLine($"Самая высокая зарплата: {richestEmployee.Name} ({richestEmployee.Salary} руб.)\n");
            }

            /*Задание 2. Обход каталога*/
            Console.WriteLine("=========== Проверка поиска файлов ===========");

            var fileFinder = new FileFinder();
            int fileCounter = 0;
            
            const int maxFilesToFind = 6; /*лимит проверок*/

            fileFinder.FileFound += (sender, args) =>
            {
                Console.WriteLine($"[Событие] Найден файл: {Path.GetFileName(args.FileName)}");
                fileCounter++;

                if (fileCounter >= maxFilesToFind)
                {
                    Console.WriteLine($"\n[Обработчик] Найдено {maxFilesToFind} файла(ов). Отменяем дальнейший поиск!");
                    args.CancelRequested = true;
                }
            };

            // string testDirectory = @"/Users/skorpk/Otus/Homework";
            string testDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine($"Начинаем поиск в: {testDirectory}");
            fileFinder.Search(testDirectory);

            Console.WriteLine("\nПрограмма завершила работу.");
            Console.ReadLine();
        }
    } 
}