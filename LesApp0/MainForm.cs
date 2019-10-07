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

namespace LesApp0
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Шлях до файлу
        /// </summary>
        private string path = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Вихід із програми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
            => this.Close();

        /// <summary>
        /// Відкриття файла для аналізу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                // присвоєння шляху/повної назви файла
                path = openFD.FileName;

                if (!(Path.GetExtension(path) == ".exe" ||
                    Path.GetExtension(path) == ".dll"))
                {
                    // якщо завантажено файл але не відповідного розширення
                    toolLb.Text = "File loaded unsuccessfully.";
                    path = string.Empty;
                    analysis.Enabled = false;
                    return;
                }

                // якщо завантажено файл з правильним розширенням
                toolLb.Text = "File loaded successfully.";
                analysis.Enabled = true;
            }
            else
            {
                // якщо натиснута відміна
                toolLb.Text = "File wasn't loaded.";
            }
        }

        /// <summary>
        /// Аналіз файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Analysis_Click(object sender, EventArgs e)
        {
            // для завантаження збірки
            Assembly assebmbly = null;
            tb.Text = string.Empty;

            try
            {
                // загрузка зборки
                assebmbly = Assembly.LoadFrom(path);
                toolLb.Text = "File loaded for analysis.";
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ім'я збірки
            tb.Text += assebmbly.FullName + Environment.NewLine;
            tb.Text += new string('-', 27) + Environment.NewLine;

            // виведення інформації про всі типи у збірці
            Type[] types = assebmbly.GetTypes();

            foreach (Type type in types)
            {
                tb.Text += Environment.NewLine + $"Тип: {type}" + Environment.NewLine;

                // члени збірки
                tb.Text += "Члени типу:" + Environment.NewLine;
                tb.Text += new string('#', 7) + Environment.NewLine;

                foreach (MemberInfo element in type.GetMembers())
                    tb.Text += $"{element.MemberType,-20}: {element.Name}" + Environment.NewLine;

                tb.Text += new string('-', 27) + Environment.NewLine;

                // методи класа
                tb.Text += "Методи типу:" + Environment.NewLine;
                tb.Text += new string('#', 7) + Environment.NewLine;

                foreach (MethodInfo method in type.GetMethods())
                {
                    if (method.GetMethodBody() != null)
                    {
                        tb.Text += $"\tПараметри методу: {method.Name}" + Environment.NewLine;

                        foreach (ParameterInfo parameter in method.GetParameters())
                        {
                            tb.Text += $"\t\tНазва параметра: {parameter.Name}" + Environment.NewLine;
                            tb.Text += $"\t\tПозиція в методі: {parameter.Position}" + Environment.NewLine;
                            tb.Text += $"\t\tТип параметра: {parameter.ParameterType}" + Environment.NewLine;
                        }
                    }
                }

                tb.Text += new string('-', 27) + Environment.NewLine;
            }

        }
    }
}
