using NumberGuess.Solid.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Infrastructure
{
    //Класс вывода в консоль
    public class ConsoleOutputWriter : IOutputWriter
    {
        void IOutputWriter.WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
