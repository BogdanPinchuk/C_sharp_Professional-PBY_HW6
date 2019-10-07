using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LesApp1.Lib.Scale;

// https://en.wikipedia.org/wiki/Scale_of_temperature
// https://uk.wikipedia.org/wiki/Температурна_шкала

// дозвіл доступу для тестування
[assembly: InternalsVisibleTo("LesApp1.Tests")]
namespace LesApp1.Lib
{
    /// <summary>
    /// Конвертер температури
    /// </summary>
    public class Temperature
    {
        /// <summary>
        /// Шкала температур
        /// </summary>
        public enum TypeScale
        {
            /// <summary>
            /// Цельсій
            /// </summary>
            Celsius,
            /// <summary>
            /// Кельвін
            /// </summary>
            Kelvin,
        }

        /// <summary>
        /// Градуси цельсія
        /// </summary>
        private double celsius;
        /// <summary>
        /// Задана шкала
        /// </summary>
        private IDegree scale;
        /// <summary>
        /// Абсолютний нуль
        /// </summary>
        private const double absZero = -273.15;

        /// <summary>
        /// Задати значення температури у відповідній шкалі
        /// </summary>
        /// <param name="value">значення температури</param>
        /// <param name="degree">шкала температури</param>
        /// <returns>градуси цельсія</returns>
        public double SetValue(double value, TypeScale degree)
        {
            // результат конвертації температури в цельсії
            double result = default(double);

            switch (degree)
            {
                case TypeScale.Celsius:
                    scale = new Celsius() { Value = value };
                    goto default;
                case TypeScale.Kelvin:
                    scale = new Kelvin() { Value = value };
                    goto default;
                default:
                    celsius = scale.CelsiusDegree;
                    break;
            }

            return celsius;
        }

    }
}
