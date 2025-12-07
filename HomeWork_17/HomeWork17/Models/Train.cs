using System.Text;

namespace RailWayTrain.Models
{
    /// <summary>
    /// Класс для состава
    /// </summary>
    public class Train 
    {
        public string TrainNumber { get; set; } = string.Empty;

        public string OriginStation { get; set; } = string.Empty;
        public string DestinationStation { get; set; } = string.Empty;

        public List<RailVehicle> Vehicles { get; } = new();

        public void AddVehicle(RailVehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        /// <summary>
        /// вес порожнего состава
        /// </summary>
        public double GetTotalWeight()
        {
            return Vehicles.Sum(v => v.CarWeightKg);
        }

        /// <summary>
        /// Общая грузоподъёмность состава
        /// </summary>
        public double GetTotalCapacity()
        {
            return Vehicles
                .OfType<FreighCar>()
                .Sum(c => c.CarWeightKg);
        }

        public void PrintInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Поезд № {TrainNumber}");
            sb.AppendLine($"Маршрут: {OriginStation} -> {DestinationStation}");
            sb.AppendLine();
            sb.AppendLine("Состав поезда:");

            foreach (var v in Vehicles)
            {
                sb.AppendLine(" - " + v);
            }

            sb.AppendLine();
            sb.AppendLine($"Общий вес состава (без груза): {GetTotalWeight():F1} т");
            sb.AppendLine($"Суммарная грузоподъёмность грузовых вагонов: {GetTotalCapacity():F1} т");

            Console.WriteLine(sb.ToString());
        }
    }
}