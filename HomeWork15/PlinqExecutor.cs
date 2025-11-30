using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15
{
    /// <summary>
    /// Реализация с применением Parallel LINQ (PLINQ).
    /// </summary>
    public class PlinqExecutor: IExecutor 
    {   
        public long CalculateSum(int n, int m)
        {
            // C PLINQ можно использовать  методы AsParallel(), WithDegreeOfParallelism() и Aggregate() для распараллеливания LINQ-запроса.

            Console.WriteLine($"ProcessorCount: {Environment.ProcessorCount}");

            return Enumerable.Range(n, m - n + 1)
                .AsParallel()
                .WithDegreeOfParallelism(Environment.ProcessorCount)
                //.Where(IExecutor.IsPrime)
                .Sum(x => (long)x);
        }
    }
}