using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Interfaces
{
 //контракт чтения введеных данных
    public interface IInputReader
    {
        string? ReadLine();
    }
}
