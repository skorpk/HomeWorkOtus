using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrototypeClone.Models
{
    /// <summary>
    /// Класс для настроек вагона
    /// </summary>

    public class CarSettings : IMyCloneable<CarSettings>
    {
        public string CarType { get; set; } = string.Empty;

        public int CarWeight { get; set; }

        public string CarNumber { get; set; } = string.Empty;

        public CarSettings Clone()
        {
            return new CarSettings
            {
                CarType = this.CarType,
                CarWeight = this.CarWeight,
                CarNumber = this.CarNumber
            };
        }

        public override string ToString()
        {
            return $"Тип вагона: {CarType}, грузоподъемность: {CarWeight}, номер вагона: {CarNumber}";
        }
    }

}
