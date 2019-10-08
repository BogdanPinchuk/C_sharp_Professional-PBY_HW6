using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Lib.Scale
{
    /// <summary>
    /// Гук
    /// </summary>
    struct Hooke : IDegree
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
        public string Name => "Hooke";

        /// <summary>
        /// Розмірність
        /// </summary>
        public string Unit => "°H";

        /// <summary>
        /// Значення температури заданої шкали
        /// </summary>
        public double Value
        {
            get { return celsius * 12 / 5; }

            set
            {
                double temp = value * 5 / 12;
                CelsiusDegree = temp;
            }
        }

    }
}
