namespace RailWayTrain.Models
{
    /// <summary>
    /// Класс для вагонов грузовых
    /// </summary>
    public class FreighCar : RailVehicle
    {
        /// <summary>
        /// Грузоподъемность вагона, кг
        /// </summary>
        public int LoadCapacityKg { get; set; }

        /// <summary>
        /// Перевозимый тип груза.
        /// </summary>
        public string FreightType { get; set; } = string.Empty;
    }
}