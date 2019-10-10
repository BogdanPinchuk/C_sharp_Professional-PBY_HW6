using System;
using System.Diagnostics;
using LesApp1.Lib;
using LesApp1.Tests.Stub;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LesApp1.Lib.Scale;

namespace LesApp1.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        /// <summary>
        /// Конвертер температури
        /// </summary>
        private Temperature converter;
        /// <summary>
        /// Допуск в градусах
        /// </summary>
        private readonly double delta = 0.01;

        [TestInitialize]
        public void BeforeTestStart()
        {
            converter = new Temperature();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "You must first set value, then get converter value.")]
        public void GetValue_Exeption()
        {
            converter.GetValue(Temperature.TypeScale.Celsius);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Temperature less absolute zero.")]
        public void SetValue_LessAsbZero_Zero()
        {
            // arrange
            converter.SetValue(StubObj.LessAbsZero, Temperature.TypeScale.Celsius);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Temperature less absolute zero.")]
        public void SetValue_LessAsbZero_Kelvin_Zero()
        {
            // arrange
            converter.SetValue(-1, Temperature.TypeScale.Kelvin);
        }

        // Примітка. BWC - BoilWaterС - 100 С кипіння води
        [TestMethod]
        public void GetValue_BWC_Kelvin()
        {
            // arrange
            converter.SetValue(StubObj.BoilWaterС, Temperature.TypeScale.Celsius);

            // act
            double actual = converter.GetValue(Temperature.TypeScale.Kelvin);

            // assert
            Assert.AreEqual(StubObj.BWK, actual, delta);

            // present
            Debug.WriteLine(converter.Scale.ConvertToString());
        }

        [TestMethod]
        public void GetValue_BWK_Celsius()
        {
            // arrange
            converter.SetValue(StubObj.BWK, Temperature.TypeScale.Kelvin);

            // act
            double actual = converter.GetValue(Temperature.TypeScale.Celsius);

            // assert
            Assert.AreEqual(StubObj.BoilWaterС, actual, delta);

            // present
            Debug.WriteLine(converter.Scale.ConvertToString());
        }

        // Далі,  заносячи значення в певній шкалі воно конвертується автоматично в цельсії
        // і повертаючи значення у цій же шкалі, воно конвертується із цельсіїв, 
        // таким чином за один раз перевіряються всі формули
        [TestMethod]
        public void GetValue_BWK_Kelvin()
            => GetValues(Temperature.TypeScale.Kelvin, StubObj.BWK);

        [TestMethod]
        public void GetValue_BWF_Fahrenheit() 
            => GetValues(Temperature.TypeScale.Fahrenheit, StubObj.BWF);

        [TestMethod]
        public void GetValue_BWRa_Rankine() 
            => GetValues(Temperature.TypeScale.Rankine, StubObj.BWRa);

        [TestMethod]
        public void GetValue_BWRo_Romer() 
            => GetValues(Temperature.TypeScale.Romer, StubObj.BWRo);

        [TestMethod]
        public void GetValue_BWN_Newton()
            => GetValues(Temperature.TypeScale.Newton, StubObj.BWN);

        [TestMethod]
        public void GetValue_BWD_Delisle()
            => GetValues(Temperature.TypeScale.Delisle, StubObj.BWD);

        [TestMethod]
        public void GetValue_BWRe_Reaumur()
            => GetValues(Temperature.TypeScale.Reaumur, StubObj.BWRe);

        [TestMethod]
        public void GetValue_BWH_Hooke()
            => GetValues(Temperature.TypeScale.Hooke, StubObj.BWH);

        [TestMethod]
        public void GetValue_BWDa_Dalton()
            => GetValues(Temperature.TypeScale.Dalton, StubObj.BWDa);

        [TestMethod]
        public void GetValue_BWL_Leiden()
            => GetValues(Temperature.TypeScale.Leiden, StubObj.BWL);

        /// <summary>
        /// Тестування методів GetValue
        /// </summary>
        /// <param name="scale">Шкала температур</param>
        /// <param name="degree">градуси</param>
        private void GetValues(Temperature.TypeScale scale, double degree)
        {
            // arrange
            converter.SetValue(degree, scale);

            // act + present
            double actС = converter.GetValue(Temperature.TypeScale.Celsius);
            Debug.WriteLine(converter.Scale.ConvertToString());
            double actual = converter.GetValue(scale);

            // assert + present
            Assert.AreEqual(StubObj.BoilWaterС, actС, delta);
            Assert.AreEqual(degree, actual, delta);
            Debug.WriteLine(converter.Scale.ConvertToString());
        }
    }
}
