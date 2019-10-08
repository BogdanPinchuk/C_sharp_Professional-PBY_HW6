using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Lib.Scale
{
    /// <summary>
    /// Ранкін
    /// </summary>
    struct Rankine : IDegree
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
                    celsius = 0;
            }
        }

        /// <summary>
        /// Назва шкали
        /// </summary>
        public string Name => "Rankine";

        /// <summary>
        /// Розмірність
        /// </summary>
        public string Unit => "°Ra";

        /// <summary>
        /// Значення температури заданої шкали
        /// </summary>
        public double Value
        {
            get { return (celsius - absZero) * 9 / 5; }

            set
            {
                double temp = (value * 5 / 9) + absZero;
                CelsiusDegree = temp;
            }
        }

    }

}
