using NumberGuess.Solid.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Interfaces
{
    public interface IGuessValuer
    {
        Result Valuer(int secret, int guess);
    }
}
