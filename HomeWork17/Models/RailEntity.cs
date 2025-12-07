namespace RailWayTrain.Models
{
    /// <summary>
    /// Базовая сущность gthtdjpjr.
    /// </summary>
    public abstract class RailEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// код объекта .
        /// </summary>
        public string Code { get; set; } = string.Empty;
    }
}