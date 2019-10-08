using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Lib.Scale
{
    /// <summary>
    /// Струкрута градусів певної шкали
    /// </summary>
    public interface IDegree
    {
        /// <summary>
        /// Назва шкали
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Розмірність
        /// </summary>
        string Unit { get; }
        /// <summary>
        /// Значення температури заданої шкали
        /// </summary>
        double Value { get; set; }
        /// <summary>
        /// Значення температури в Цельсіях
        /// </summary>
        double CelsiusDegree { get; set; }

    }

    /// <summary>
    /// Вивід інформації
    /// </summary>
    /// <returns></returns>
    internal static class ExtentionMethod
    {
        internal static string ConvertToString(this IDegree degree)
            => $"{degree.Value} {degree.Unit}";
    }
}
