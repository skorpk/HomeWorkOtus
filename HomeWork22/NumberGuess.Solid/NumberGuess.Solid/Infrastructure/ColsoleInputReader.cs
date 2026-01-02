using NumberGuess.Solid.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Infrastructure
{
    //Класс для чтения введенных данных пользователем
    public class ColsoleInputReader : IInputReader
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
