using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Lib.Scale
{
    /// <summary>
    /// Дальтон
    /// </summary>
    struct Dalton : IDegree
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
        public string Name => "Dalton";

        /// <summary>
        /// Розмірність
        /// </summary>
        public string Unit => "°Da";

        /// <summary>
        /// Значення температури заданої шкали
        /// </summary>
        public double Value
        {
            get
            {
                return 100 *
                  Math.Log10((absZero - celsius) / absZero) /
                  Math.Log10((absZero - 100) / absZero);
            }

            set
            {
                double temp = absZero * (1 - Math.Pow(((absZero - 100) / absZero), value / 100));
                CelsiusDegree = temp;
            }
        }

    }
}
