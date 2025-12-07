namespace RailWayTrain.Models
{
    /// <summary>
    /// Класс для локомотивов
    /// </summary>
    public class Locomotive : RailVehicle
    {
        /// <summary>
        /// Мощность локомотива в кВт
        /// </summary>
        public double PowerKw { get; set; }
        /// <summary>
        /// Тип локомотива (тепловоз, электровоз)
        /// </summary>
        public string LocomotiveType { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"Номер {CarNumber}, тип: {LocomotiveType}, мощность: {PowerKw} кВт";
        }
    }
}