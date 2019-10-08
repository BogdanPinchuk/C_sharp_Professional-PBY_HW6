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
        public void SetValue_LessAsbZero_Zero()
        {
            // arrange
            converter.SetValue(StubObj.LessAbsZero, Temperature.TypeScale.Celsius);

            // act
            double actual = converter.GetValue(Temperature.TypeScale.Celsius);

            // assert
            Assert.AreNotEqual(StubObj.LessAbsZero, actual);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void SetValue_LessAsbZero_Kelvin_Zero()
        {
            // arrange
            converter.SetValue(-1, Temperature.TypeScale.Kelvin);

            // act
            double actual = converter.GetValue(Temperature.TypeScale.Celsius);
            double actK = converter.GetValue(Temperature.TypeScale.Kelvin);

            // assert
            Assert.AreEqual(0, actual);
            Assert.AreNotEqual(-1, actK);
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
        {
            // arrange
            converter.SetValue(StubObj.BWK, Temperature.TypeScale.Kelvin);

            // act
            double actС = converter.GetValue(Temperature.TypeScale.Celsius);
            double actual = converter.GetValue(Temperature.TypeScale.Kelvin);

            // assert
            Assert.AreEqual(StubObj.BoilWaterС, actС, delta);
            Assert.AreEqual(StubObj.BWK, actual, delta);

            // present
            Debug.WriteLine(converter.Scale.ConvertToString());
        }

        [TestMethod]
        public void GetValue_BWF_Fahrenheit()
        {
            // arrange
            converter.SetValue(StubObj.BWF, Temperature.TypeScale.Fahrenheit);

            // act
            double actС = converter.GetValue(Temperature.TypeScale.Celsius);
            double actual = converter.GetValue(Temperature.TypeScale.Fahrenheit);

            // assert
            Assert.AreEqual(StubObj.BoilWaterС, actС, delta);
            Assert.AreEqual(StubObj.BWF, actual, delta);

            // present
            Debug.WriteLine(converter.Scale.ConvertToString());
        }

        [TestMethod]
        public void GetValue_BWRa_Rankine()
        {
            // arrange
            converter.SetValue(StubObj.BWRa, Temperature.TypeScale.Rankine);

            // act
            double actС = converter.GetValue(Temperature.TypeScale.Celsius);
            double actual = converter.GetValue(Temperature.TypeScale.Rankine);

            // assert
            Assert.AreEqual(StubObj.BoilWaterС, actС, delta);
            Assert.AreEqual(StubObj.BWRa, actual, delta);

            // present
            Debug.WriteLine(converter.Scale.ConvertToString());
        }


    }
}
