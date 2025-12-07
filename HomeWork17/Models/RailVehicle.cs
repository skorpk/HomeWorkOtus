namespace RailWayTrain.Models
{
    /// <summary>
    /// Единица подвижного состава(вагон, контейнеровоз)
    /// </summary>
    public abstract class RailVehicle : RailEntity
    {
        /// <summary>
        /// Номер вагона
        /// </summary>
        public string CarNumber { get; set; } = string.Empty;

        /// <summary>
        /// Тара или масса, т.
        /// </summary>
        public int CarWeightKg { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} №{CarNumber}, вес {CarWeightKg} кг";
        }
    }
}