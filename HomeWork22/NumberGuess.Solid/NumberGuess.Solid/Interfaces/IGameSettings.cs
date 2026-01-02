using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Interfaces
{
    //контракт настройки игры
    public interface IGameSettings
    {
        int Min { get; }
        int Max { get; }
        int MaxNumberAttempts { get; }
    }
}
