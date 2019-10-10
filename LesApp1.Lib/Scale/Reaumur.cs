using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Lib.Scale
{
    /// <summary>
    /// Реомюр
    /// </summary>
    struct Reaumur : IDegree
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
        public string Name => "Reaumur";

        /// <summary>
        /// Розмірність
        /// </summary>
        public string Unit => "°Re";

        /// <summary>
        /// Значення температури заданої шкали
        /// </summary>
        public double Value
        {
            get { return celsius * 4 / 5; }

            set
            {
                double temp = value * 5 / 4;
                CelsiusDegree = temp;
            }
        }

    }
}
