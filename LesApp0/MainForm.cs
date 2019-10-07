using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        /// Відкриття файла аналізу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFile_Click(object sender, EventArgs e)
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
    }
}
