﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LesApp2
{
    public partial class MainForm : Form
    {
        private delegate double delSGV(double value, Enum degree);

        /// <summary>
        /// Шлях до збірки
        /// </summary>
        //private readonly string path = @"e:\Documents\Documents\C# .Net Developer\Lessons" +
        //    @"\C# Для профессионалов\Home Work\6\PBY_HW6\LesApp1.Lib\bin\Debug\LesApp1.Lib.dll";
        private readonly string path = @"e:\Bohdan\Курси C# .Net\C# Для професионалов\Home Work" +
            @"\6\PBY_HW6\LesApp1.Lib\bin\Debug\LesApp1.Lib.dll";
        //private readonly string path = @"Resources\LesApp1.Lib.dll";
        /// <summary>
        /// Збірка
        /// </summary>
        private Assembly assembly = null;
        /// <summary>
        /// Екземпляр класа розрахунку темпаратури
        /// </summary>
        private object temperature = null;
        /// <summary>
        /// Масив перерахунку TypeScale
        /// </summary>
        private Enum[] eTypeScale;
        /// <summary>
        /// Вхідна температура
        /// </summary>
        public double inputDegree;
        /// <summary>
        /// Введення температури
        /// </summary>
        private delSGV SetValue;
        /// <summary>
        /// Отримання температури
        /// </summary>
        private delSGV GetValue;

        public MainForm()
        {
            InitializeComponent();

            // Завантаження збірки
            LoadLib();
            if (assembly != null)
            {
                GetScales();
            }
        }

        /// <summary>
        /// Завантаження збірки
        /// </summary>
        private void LoadLib()
            => LoadLib(path);

        /// <summary>
        /// Завантаження збірки
        /// </summary>
        /// <param name="path">шлях</param>
        private void LoadLib(string path)
        {
            try
            {
                assembly = Assembly.LoadFrom(path);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        /// <summary>
        /// Отримання температурних шкал
        /// </summary>
        private void GetScales()
        {
            if (assembly == null)
                return;

            // достаємо enum - який відображається як вложений тип
            //Type @enum = assembly.GetType("Temperature").GetNestedType("TypeScale");
            Type @class = assembly.GetType("LesApp1.Lib.Temperature", false, true);
            temperature = Activator.CreateInstance(@class);
            Type @enum = temperature.GetType().GetNestedType("TypeScale");
            eTypeScale = @enum.GetEnumValues().Cast<Enum>().ToArray();

            // отримання методів
            SetValue = (value, degree) => (double)@class.GetMethod("SetValue")
                .Invoke(temperature, new object[] { value, degree });
            GetValue = (value, degree) => (double)@class.GetMethod("GetValue")
                .Invoke(temperature, new object[] { degree });

            // отримання свойства
            //var temp = @class.GetProperty("Scale").GetValue(temperature)

            // заповнення даними comboboxes
            foreach (var i in eTypeScale)
            {
                cbGet.Items.Add(i.ToString());
                cbSet.Items.Add(i.ToString());
            }

            // вибір дефолтних параметрів
            cbGet.SelectedIndex = 0;
            cbSet.SelectedIndex = 0;
        }

        /// <summary>
        /// При натисканні клавіші Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (double.TryParse(tbSet.Text.Trim().Replace('.', ','), out inputDegree))
                {
                    tbSet.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
                    slInfo.Text = "Help information.";

                    try
                    {
                        Converter();
                    }
                    catch (Exception ex)
                    {
                        // за умови якщо температура менше абсолютного нуля
                        tbSet.ForeColor = Color.FromKnownColor(KnownColor.Red);
                        slInfo.Text = ex.Message;
                    }
                }
                else
                {
                    // червоний колір вказує на помилку
                    tbSet.ForeColor = Color.FromKnownColor(KnownColor.Red);
                    slInfo.Text = "Error input data.";
                }
            }
        }

        /// <summary>
        /// Конвертер температури
        /// </summary>
        private void Converter()
        {

        }
    }
}
