using System;
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
        private delegate double delSV(double value, Enum degree);
        private delegate double delGV(Enum degree);

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
        private delSV SetValue;
        /// <summary>
        /// Отримання температури
        /// </summary>
        private delGV GetValue;

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
            Type @class = assembly.GetType("LesApp1.Lib.Temperature", false, true);
            temperature = Activator.CreateInstance(@class);
            Type @enum = temperature.GetType().GetNestedType("TypeScale");
            eTypeScale = @enum.GetEnumValues().Cast<Enum>().ToArray();

            // отримання методів
            SetValue = (value, degree) => (double)@class.GetMethod("SetValue")
                .Invoke(temperature, new object[] { value, degree });
            GetValue = (degree) => (double)@class.GetMethod("GetValue")
                .Invoke(temperature, new object[] { degree });

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
        /// Отримання значення свойств
        /// </summary>
        /// <returns></returns>
        private string GetUnit()
        {
            // достаємо enum - який відображається як вложений тип
            Type @class = assembly.GetType("LesApp1.Lib.Temperature", false, true);
            // отримання свойства
            var a0 = @class.GetProperty("Scale").PropertyType;
            var a1 = a0.GetProperty("Unit");
            var a2 = a1.GetValue(@class);
            //todo: налаштувати дані властивостей
            string unit = (string)(@class.GetProperty("Scale").PropertyType
                .GetProperty("Unit").GetValue(@class));

            return unit;
        }

        /// <summary>
        /// При натисканні клавіші Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Converter();
        }

        /// <summary>
        /// Конвертер температури
        /// </summary>
        private void Converter()
        {
            if (double.TryParse(tbSet.Text.Trim().Replace('.', ','), out inputDegree))
            {
                tbSet.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
                slInfo.Text = "Help information.";

                //try
                //{
                    // установка значення
                    SetValue(inputDegree, eTypeScale[cbSet.SelectedIndex]);
                    // установка розмірності на вхідну величину
                    lSet.Text = GetUnit();
                    // отримання розрахованого значення
                    GetValue(eTypeScale[cbGet.SelectedIndex]);
                    // установка розмірності на вихідну величину
                    lGet.Text = GetUnit();
                //}
                //catch (Exception ex)
                //{
                //    // за умови якщо температура менше абсолютного нуля
                //    tbSet.ForeColor = Color.FromKnownColor(KnownColor.Red);
                //    slInfo.Text = ex.Message;
                //}
            }
            else
            {
                // червоний колір вказує на помилку
                tbSet.ForeColor = Color.FromKnownColor(KnownColor.Red);
                slInfo.Text = "Error input data.";
            }
        }

        /// <summary>
        /// Коли змінюється вхідна шкала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSet_SelectedIndexChanged(object sender, EventArgs e)
            => Converter();

        /// <summary>
        /// Коли змінюється вихідна шкала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbGet_SelectedIndexChanged(object sender, EventArgs e)
            => Converter();
    }
}
