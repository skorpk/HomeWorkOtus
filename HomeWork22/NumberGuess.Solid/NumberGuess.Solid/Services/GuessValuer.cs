using NumberGuess.Solid.Enum;
using NumberGuess.Solid.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Services
{
    //Класс реализации логики сравнения
    public class GuessValuer : IGuessValuer
    {
        public Result Valuer(int secret, int guess)
        {
            if (secret > guess) { return Result.TooSmall; }
            if (secret < guess) { return Result.TooLarge; }
            return Result.Correct;
        }
    }
}
