using Microsoft.Extensions.Configuration;
using NumberGuess.Solid.Engine;
using NumberGuess.Solid.Infrastructure;
using NumberGuess.Solid.Interfaces;
using NumberGuess.Solid.Services;
using System.Runtime.InteropServices;

namespace NumberGuess.Solid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()  
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            IGameSettings settings = new JsonGameSettings(config);
            INumberGenerator generator = new Services.RandomNumberGenerator();
            IInputReader input = new Infrastructure.ColsoleInputReader();
            IOutputWriter output = new Infrastructure.ConsoleOutputWriter();
            IGuessValuer valuer = new Services.GuessValuer();

            var engine = new GameEngine(settings, generator, input, output, valuer);
            engine.Run();
        }
    }
}
