using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Lib.Scale
{
    /// <summary>
    /// Фаренгейт
    /// </summary>
    struct Leiden : IDegree
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
        public string Name => "Leiden";

        /// <summary>
        /// Розмірність
        /// </summary>
        public string Unit => "°L";

        /// <summary>
        /// Значення температури заданої шкали
        /// </summary>
        public double Value
        {
            get { return celsius + 253; }

            set
            {
                double temp = value - 253;
                CelsiusDegree = temp;
            }
        }

    }
}
