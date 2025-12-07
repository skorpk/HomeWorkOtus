using StandartPrototypeClone.Models;
namespace StandartPrototypeClone
{
    internal class Program
    {
        /*
         * Плюсы стандартного метода клонирования:
         * 1. Встроен в .NET + поддержка всех версий
         * 2. Не требует создания дополнительных интерфейсов
         * 3. Простота реализации
         * 4. Хорошо подходит для простых объектов
         * 5. Универсален
         * Минусы стандартного метода клонирования:
         * 1. Возвращает тип object?, требуется приведение типов
         * 2. Неопнятно какой тип клонирования (глубокое или поверхностное копирование).
         * 3. Легко расширить
         */
        static void Main(string[] args)
        {
            var carSettings = new CarSettings
            {
                CarType = "Платформа",
                CarWeight = 50000,
                CarNumber = "123-456"
            };

            Console.WriteLine("Первоначальные настройки вагона");
            Console.WriteLine(carSettings);
            Console.WriteLine();
            //Клонирование объекта
            var clonedCarSettings = (CarSettings)carSettings.Clone();

            clonedCarSettings.CarNumber = "654-321";
            clonedCarSettings.CarWeight = 60000;

            Console.WriteLine("Настройки клонированного вагона");
            Console.WriteLine(clonedCarSettings);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
