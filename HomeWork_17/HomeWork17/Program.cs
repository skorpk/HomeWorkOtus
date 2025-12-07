using RailWayTrain.Models;

namespace RailWayTrain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаём локомотив
            var locomotive = new Locomotive
            {
                Code = "LCM-001",
                CarNumber = "2ТЭ116-123",
                CarWeightKg = 138000,
                PowerKw = 3000,
                LocomotiveType = "Тепловоз"
            };

            // Создаём несколько грузовых вагонов
            var hopper1 = new HopperCar
            {
                Code = "HPR-01",
                CarNumber = "60512345",
                CarWeightKg = 22500,
                LoadCapacityKg = 68000,
                FreightType = "Зерно",
                IsTopHatch = true,
                IsBottomHatch = true
            };

            var hopper2 = new HopperCar
            {
                Code = "HPR-02",
                CarNumber = "60567890",
                CarWeightKg = 23000,
                LoadCapacityKg = 70000,
                FreightType = "Пшеница",
                IsTopHatch = true,
                IsBottomHatch = true
            };            

            // Формируем поезд
            var train = new Train
            {
                TrainNumber = "245А",
                OriginStation = "Гусев",
                DestinationStation = "Новороссийск(эксп)"
            };

            train.AddVehicle(locomotive);
            train.AddVehicle(hopper1);
            train.AddVehicle(hopper2);

            // Вывод информации
            train.PrintInfo();

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
