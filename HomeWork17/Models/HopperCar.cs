namespace RailWayTrain.Models
{
    /// <summary>
    /// Класс для хоппер вагонов
    /// </summary>
    public class HopperCar : FreighCar
    {
        /// <summary>
        /// Пристутствует ли верхние люки для загрузки зерна
        /// </summary>
        public bool IsTopHatch
        {
            get; set;
        }

        public bool IsBottomHatch
        {
            get; set;
        }

        public override string ToString()
        {
            return $"тип груза: {FreightType}" + $", грузоподъемность: {LoadCapacityKg} кг" + ", " +
                $", Верхние люки: {(IsTopHatch ? "есть" : "нет")}, Нижние люки: {(IsBottomHatch ? "есть" : "нет")}";
        }
    }
}