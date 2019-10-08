using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LesApp1.Lib.Scale;

// https://en.wikipedia.org/wiki/Scale_of_temperature
// https://uk.wikipedia.org/wiki/Температурна_шкала
// https://ru.wikipedia.org/wiki/Единицы_измерения_температуры

// Примітка. Градуси Цельсія загально прийнята шкала вимірювання згідно системи СІ,
// фаренгейти використовуються в США, що до кельвінів - то цю шкалу практично не 
// використовують в суспільстві окрім як наукових статтей, книг і формул.
// Отже кельвіни використовують лише для досліджень, в "биту" ж користуються іншими шкалами
// Найчастіше кельвіни використовуються для синтезу, розгахунку енергетики теле- та тепловізійних 
// систем спостереження. Із температури визначають потік випромінбвання (світла) і т.д. (див. формула Планка)

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
            /// <summary>
            /// Фаренгейт
            /// </summary>
            Fahrenheit,
            /// <summary>
            /// Ранкін
            /// </summary>
            Rankine,
            /// <summary>
            /// Ремер
            /// </summary>
            Romer,
            /// <summary>
            /// Ньютон
            /// </summary>
            Newton,
            /// <summary>
            /// Деліль
            /// </summary>
            Delisle,
            /// <summary>
            /// Реомюр
            /// </summary>
            Reaumur,
            /// <summary>
            /// Гук
            /// </summary>
            Hooke,
            /// <summary>
            /// Дальтон
            /// </summary>
            Dalton,
            /// <summary>
            /// Лейден
            /// </summary>
            Leiden,
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
        /// Отримати шкалу
        /// </summary>
        public IDegree Scale
            => scale;

        /// <summary>
        /// Задати значення температури у відповідній шкалі
        /// </summary>
        /// <param name="value">значення температури</param>
        /// <param name="degree">шкала температури</param>
        /// <returns>градуси цельсія</returns>
        public double SetValue(double value, TypeScale degree)
        {
            switch (degree)
            {
                case TypeScale.Celsius:
                    scale = new Celsius() { Value = value };
                    goto default;
                case TypeScale.Kelvin:
                    scale = new Kelvin() { Value = value };
                    goto default;
                case TypeScale.Fahrenheit:
                    scale = new Fahrenheit() { Value = value };
                    goto default;
                case TypeScale.Rankine:
                    scale = new Rankine() { Value = value };
                    goto default;
                default:
                    celsius = scale.CelsiusDegree;
                    break;
            }

            return celsius;
        }

        /// <summary>
        /// Отримати значення температури у відповідній шкалі
        /// </summary>
        /// <param name="degree">шкала температури</param>
        /// <returns>градуси цельсія</returns>
        public double GetValue(TypeScale degree)
        {
            if (scale == null)
            {
                throw new Exception("You must first set value, then get converter value.");
            }

            switch (degree)
            {
                case TypeScale.Celsius:
                    scale = new Celsius() { CelsiusDegree = celsius };
                    break;
                case TypeScale.Kelvin:
                    scale = new Kelvin() { CelsiusDegree = celsius };
                    break;
                case TypeScale.Fahrenheit:
                    scale = new Fahrenheit() { CelsiusDegree = celsius };
                    break;
                case TypeScale.Rankine:
                    scale = new Rankine() { CelsiusDegree = celsius };
                    break;
            }

            return scale.Value;
        }
    }
}
