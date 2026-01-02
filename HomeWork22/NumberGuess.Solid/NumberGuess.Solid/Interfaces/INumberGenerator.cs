using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Interfaces
{
    //контракт генерации числа
    public interface INumberGenerator
    {
        int Next(int minInclusive, int maxInclusive);
    }
}
