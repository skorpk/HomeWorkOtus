using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using HomeWork15;
using System.Diagnostics;

namespace HomeWork15
{
    public class Program
    {
        // Параллельное вычисление суммы простых чисел в заданном диапазоне
        // Натуральное число, большее 1 , называется простым, если оно ни на что не делится, кроме себя и 1. 
        private static void Main(string[] args)
        {
         
            //Диапазон чисел
            const int N = 2;
            //const int M = 10_000_000;

            int[] sizes = { //10_000,
                100_000, 1_000_000, 10_000_000,
                //100_000_000
                };
            //получение информации о системе
            SystemInformationGet();
            #region Последовательное выполнение
            foreach (int size in sizes)
            {
                Console.WriteLine($"Size: {/*M*/size}");
                Console.WriteLine("Реализация последовательного вычисления");
                var sw = Stopwatch.StartNew();
                long sum = CalculateSequential(N, /*M*/size);
                sw.Stop();

                var sequentialTime = sw.ElapsedMilliseconds;
                Console.WriteLine($"SequentialSum: {sum}, ExecutionTime: {sequentialTime}");
            }
            #endregion

            Console.WriteLine(new string('=', 60));
            Console.WriteLine("");
            
            #region Реализация с Threads
            foreach (int size in sizes)
            {
                Console.WriteLine("Реализация с Threads");
                IExecutor threadExecutor = new ThreadExecutor();
                var sw = Stopwatch.StartNew();

                long threadSum = Run(threadExecutor, N, size);
                sw.Stop();
                var threadTime = sw.ElapsedMilliseconds;
                Console.WriteLine($"ThreadSum: {threadSum}, ExecutionTime: {threadTime}");
            }
            #endregion
            
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("");
            
            #region Реализация с PLINQ
            foreach (int size in sizes)
            {
                Console.WriteLine("Реализация с PLINQ");
                IExecutor plinqExecutor = new PlinqExecutor();

                var sw = Stopwatch.StartNew();
                long plinqSum = Run(plinqExecutor, N, size);
                sw .Stop();
                var plinqTime = sw.ElapsedMilliseconds;
                Console.WriteLine($"PlinqSum: {plinqSum}, ExecutionTime: {plinqTime}");
            }
            #endregion
            
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("");
             Console.ReadKey();
        }
            #region Последовательная реализация

            /// Метод вычисления суммы чисел в заданном диапазоне
            static long CalculateSequential(int n, int m)
            {
                long sum = 0;
                for (int num = n; num <= m; num++)
                {
                    sum += num;
                }
                return sum;
            }
            #endregion  

        public static void SystemInformationGet()
        {

            Console.WriteLine("===============Информация о системе===============");
            Console.WriteLine($"ОС: {Environment.OSVersion}");
            Console.WriteLine($"Версия ОС: {Environment.OSVersion.Version}");
            Console.WriteLine($"Платформа: {Environment.OSVersion.Platform}");
            Console.WriteLine($"64-битная ОС: {Environment.Is64BitOperatingSystem}");
            Console.WriteLine($"64-битный процесс: {Environment.Is64BitProcess}");
            Console.WriteLine($"Версия CLR: {Environment.Version}");
            Console.WriteLine($"Количество процессоров: {Environment.ProcessorCount}");
            Console.WriteLine($"Разрядность: {(Environment.Is64BitProcess ? "64-bit" : "32-bit")}");
            Console.WriteLine($"Размер страницы памяти: {Environment.SystemPageSize} bytes");
            Console.WriteLine($"Размер памяти: {GC.GetGCMemoryInfo().TotalAvailableMemoryBytes /1024 /1024}Mb");            
            Console.WriteLine(new string('=', 60));
        }

        static long Run(IExecutor executor, int n, int m)
        {
            return executor.CalculateSum(n, m);
        }
    }
}