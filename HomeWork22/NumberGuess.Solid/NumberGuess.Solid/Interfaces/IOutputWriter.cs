using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Interfaces
{
    //контракт вывода данных
    public interface IOutputWriter
    {
        void WriteLine(string message);
    }
}
