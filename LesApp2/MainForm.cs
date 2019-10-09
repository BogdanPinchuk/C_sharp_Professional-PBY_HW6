using System;
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
        /// <summary>
        /// Шлях до збірки
        /// </summary>
        private readonly string path = @"e:\Documents\Documents\C# .Net Developer\Lessons" + 
            @"\C# Для профессионалов\Home Work\6\PBY_HW6\LesApp1.Lib\bin\Debug\LesApp1.Lib.dll";
        //private readonly string path = @"Resources\LesApp1.Lib.dll";
        /// <summary>
        /// Збірка
        /// </summary>
        private Assembly assembly = null;

        public MainForm()
        {
            InitializeComponent();

            // Завантаження збірки
            LoadLib();
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

    }
}
