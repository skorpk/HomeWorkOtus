using NumberGuess.Solid.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Services
{
    //Класс для генерации случайного числа
    public class RandomNumberGenerator : INumberGenerator
    {
        private readonly Random _random = new();

        public int Next(int minInclusive, int maxInclusive)
        {
            return _random.Next(minInclusive, maxInclusive+1);
        }
    }
}
