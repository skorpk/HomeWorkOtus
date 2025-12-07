using MyPrototypeClone.Models;

namespace MyPrototypeClone
{
    internal class Program
    {
        /*
         * Плюсы собственного интерфейса клонирования:
         * 1. Возврощает явно указанный тип при Clone()
         * 2. Позволяет контролировать поведение клонирования
         * 3. Разработчик сам определяет тип клонирования(глубокое или поверхностное копирование)
         * Минусы собственного интерфейса клонирования:
         * 1. Требует создания дополнительных интерфейсов
         * 2. Требует реализации метода Clone() в каждом классе
         * 3. Не работает с внешними библиотеками
         * 3. Разработчик сам определяет как клонировать сложные объекты
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
            var clonedCarSettings = carSettings.Clone();

            clonedCarSettings.CarNumber = "654-321";
            clonedCarSettings.CarWeight = 60000;

            Console.WriteLine("Настройки клонированного вагона вагона");
            Console.WriteLine(clonedCarSettings);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
