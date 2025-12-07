using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartPrototypeClone.Models
{
    public class CarSettings : ICloneable
    {
        public string CarType { get; set; } = string.Empty;

        public int CarWeight { get; set; }

        public string CarNumber { get; set; } = string.Empty;

        public object Clone()
        {            
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Тип вагона: {CarType}, грузоподъемность: {CarWeight}, номер вагона: {CarNumber}";
        }
    }
}
