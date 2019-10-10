using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Lib.Scale
{
    /// <summary>
    /// Кельвін
    /// </summary>
    struct Kelvin : IDegree
    {
        /// <summary>
        /// Градуси цельсія
        /// </summary>
        private double celsius;
        private const double absZero = -273.15;

        /// <summary>
        /// Цельсій
        /// </summary>
        public double CelsiusDegree
        {
            get { return celsius; }

            set
            {
                if (value >= absZero)
                    celsius = value;
                else
                    throw new Exception("Temperature less absolute zero.");
            }
        }

        /// <summary>
        /// Назва шкали
        /// </summary>
        public string Name => "Kelvin";

        /// <summary>
        /// Розмірність
        /// </summary>
        public string Unit => "K";

        /// <summary>
        /// Значення температури заданої шкали
        /// </summary>
        public double Value
        {
            get { return celsius + 273.15; }

            set
            {
                double temp = value - 273.15;
                CelsiusDegree = temp;
            }
        }
    }
}
