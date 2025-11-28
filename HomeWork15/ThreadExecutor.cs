using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15
{    
    /// <summary>
    /// Реализация с использованием классических потоков (System.Threading.Thread) 
    /// </summary>
    /*
     * Разбиваю диапазон [n,m] на поддиапазоны -> List
     * Для каждго такого диапазона считаем частичную сумму в отдельном потоке 
     * Объединяем + суммируем частичные суммы 
     */
    public class ThreadExecutor 
    {
        public long CalculateSum(int n, int m)
        {
            int cores = Environment.ProcessorCount;
            long length = m - n + 1L;

            // ограничавю количество потоков
            int threadsCount = (int)Math.Min(length, cores);

            long chunkSize = length / threadsCount;

            // список поддиапазонов
            var ranges = new List<(int start, int end)>(threadsCount);

            int currentStart = n;
            for (int i = 0; i < threadsCount; i++)
            {
                int start = currentStart;
                long size = (i == threadsCount - 1) ? (m - start + 1L) : chunkSize;
                int end = (int)(start + size - 1);

                ranges.Add((start, end));
                currentStart = end + 1;
            }

            // частичные суммы + список потоков
            var threads = new List<Thread>(threadsCount);
            long[] partialSums = new long[threadsCount];

            for (int i = 0; i < ranges.Count; i++)
            {
                int idx = i;                    
                var range = ranges[i];          

                Thread t = new Thread(() =>
                {
                    long localSum = 0;
                    for (int num = range.start; num <= range.end; num++)
                        localSum += num;

                    partialSums[idx] = localSum;
                });

                threads.Add(t);
                t.Start();
            }

            foreach (var t in threads)
                t.Join();

            long total = 0;
            foreach (var s in partialSums)
                total += s;

            return total;
        }

        /*
        public long CalculateSum(int n, int m)
        {
            //Разделим диапазон[N, M] на K непересекающихся поддиапазонов(K = количество логических ядер CPU).
            int cores = Environment.ProcessorCount;
            long chunkSize = (m - n + 1L) / cores;
            var threads = new List<Thread>(cores);
            long total = 0;
            object lockObj = new();

            //Для каждого поддиапазона создадим отдельный поток, который вычислит сумму простых чисел в своей части.
            for (int i = 0; i < cores; i++)
            {
                int start = (int)(n + i * chunkSize);
                int end = (i == cores - 1) ? m : (int)(start + chunkSize - 1);

                Thread t = new(() =>
                {
                    long localSum = 0;
                    for (int num = start; num <= end; num++)
                        localSum += num;

                    lock (lockObj) { total += localSum; }
                });

                threads.Add(t);
                t.Start();
            }

            //Синхронизируем потоки и объединим результаты.
            foreach (Thread t in threads) t.Join();
            return total;
        }
        */
    }
}
