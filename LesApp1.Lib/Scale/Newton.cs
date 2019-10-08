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
    struct Newton : IDegree
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
        public string Name => "Newton";

        /// <summary>
        /// Розмірність
        /// </summary>
        public string Unit => "°N";

        /// <summary>
        /// Значення температури заданої шкали
        /// </summary>
        public double Value
        {
            get { return celsius * 33 / 100; }

            set
            {
                double temp = value * 100 / 33;
                CelsiusDegree = temp;
            }
        }

    }
}
