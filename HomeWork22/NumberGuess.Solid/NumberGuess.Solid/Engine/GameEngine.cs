using NumberGuess.Solid.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Engine
{
    public class GameEngine
    {
        private readonly IGameSettings _settings;
        private readonly INumberGenerator _generator;
        private readonly IInputReader _input;
        private readonly IOutputWriter _output;
        private readonly IGuessValuer _guessValuer;
        public GameEngine(IGameSettings settings, INumberGenerator generator, IInputReader input, IOutputWriter output, IGuessValuer guesValuer)
        { 
            _settings = settings;
            _generator = generator;
            _input = input;
            _output = output;
            _guessValuer = guesValuer;
        }
        public void Run()
        {
            int secret = _generator.Next(_settings.Min, _settings.Max);
            int numberAttempts = _settings.MaxNumberAttempts;

            _output.WriteLine($"Диапазон для угадывания числа от {_settings.Min} до {_settings.Max}");
            _output.WriteLine($"Количество попыток состовляет: {_settings.MaxNumberAttempts}");
            while (numberAttempts > 0) 
            {
                _output.WriteLine($"Введите число");
                var text = _input.ReadLine();

                if (!int.TryParse(text, out int guess))
                {
                    _output.WriteLine("Ошибка. Введите число");
                    continue;//возможно стоит добавить счетчик ошибочного ввода
                }
                if (guess < _settings.Min || guess > _settings.Max)
                {
                    _output.WriteLine($"Диапазон для угадывания числа состовляет от {_settings.Min} до {_settings.Max}");
                    continue;//возможно стоит добавить счетчик ошибочного ввода
                }
                numberAttempts--;//если все ОК засчитываем попытку
                var _result = _guessValuer.Valuer(secret, guess);
                switch (_result)
                {
                    case Enum.Result.TooSmall:
                        _output.WriteLine("Не угадал. Введеное число больше");
                        break;
                    case Enum.Result.TooLarge:
                        _output.WriteLine("Не угадал. Введеное число меньше");
                        break;
                    case Enum.Result.Correct:
                        _output.WriteLine($"Угадал! Загаданное число {secret}");
                        return;
                }
            }

            _output.WriteLine($"Все попытки закончились. загаданое число {secret}.");
        }
    }
}
