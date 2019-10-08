using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Tests.Stub
{
    static class StubObj
    {
        /// <summary>
        /// Температура нижче абсолютного нуля
        /// </summary>
        public static double LessAbsZero = -274;
        /// <summary>
        /// Температура кипіння води (ТКВ) - Цельсій
        /// </summary>
        public static double BoilWaterС = 100;
        /// <summary>
        /// ТКВ - Кельвін
        /// </summary>
        public static double BWK = 373.15;
        /// <summary>
        /// ТКВ - Фаренгейт
        /// </summary>
        public static double BWF = 212;
        /// <summary>
        /// ТКВ - Ранкін
        /// </summary>
        public static double BWRa = 671.67;
    }
}
