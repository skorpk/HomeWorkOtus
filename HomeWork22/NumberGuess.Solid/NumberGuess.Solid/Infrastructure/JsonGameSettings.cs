using Microsoft.Extensions.Configuration;
using NumberGuess.Solid.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess.Solid.Infrastructure
{
    //Класс для чтения настроек из конигурационного файла
    public class JsonGameSettings : IGameSettings
    {
        public int Min { get; }
        public int Max { get; }
        public int MaxNumberAttempts { get; }

        public JsonGameSettings(IConfiguration config)
        {
            var section = config.GetSection("Game");
            Min = section.GetValue<int>("Min");
            Max = section.GetValue<int>("Max");
            MaxNumberAttempts = section.GetValue<int>("MaxNumberAttempts");

            //Проверки от неправильных настроек
            if (Min >= Max) throw new ArgumentException("Значение Max должно быть больше Min");
            if (MaxNumberAttempts < 1) throw new ArgumentException("Количество попыток не может быть меньше 1"); 
        }

    }
}
