namespace LesApp2
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSet = new System.Windows.Forms.TextBox();
            this.tbGet = new System.Windows.Forms.TextBox();
            this.cbSet = new System.Windows.Forms.ComboBox();
            this.cbGet = new System.Windows.Forms.ComboBox();
            this.lSet = new System.Windows.Forms.Label();
            this.lGet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbSet
            // 
            this.tbSet.Location = new System.Drawing.Point(12, 34);
            this.tbSet.Name = "tbSet";
            this.tbSet.Size = new System.Drawing.Size(147, 22);
            this.tbSet.TabIndex = 0;
            // 
            // tbGet
            // 
            this.tbGet.Location = new System.Drawing.Point(217, 34);
            this.tbGet.Name = "tbGet";
            this.tbGet.ReadOnly = true;
            this.tbGet.Size = new System.Drawing.Size(147, 22);
            this.tbGet.TabIndex = 1;
            // 
            // cbSet
            // 
            this.cbSet.FormattingEnabled = true;
            this.cbSet.Location = new System.Drawing.Point(12, 87);
            this.cbSet.Name = "cbSet";
            this.cbSet.Size = new System.Drawing.Size(147, 24);
            this.cbSet.TabIndex = 2;
            // 
            // cbGet
            // 
            this.cbGet.FormattingEnabled = true;
            this.cbGet.Location = new System.Drawing.Point(217, 87);
            this.cbGet.Name = "cbGet";
            this.cbGet.Size = new System.Drawing.Size(147, 24);
            this.cbGet.TabIndex = 3;
            // 
            // lSet
            // 
            this.lSet.AutoSize = true;
            this.lSet.Location = new System.Drawing.Point(165, 37);
            this.lSet.Name = "lSet";
            this.lSet.Size = new System.Drawing.Size(31, 17);
            this.lSet.TabIndex = 4;
            this.lSet.Text = "unit";
            // 
            // lGet
            // 
            this.lGet.AutoSize = true;
            this.lGet.Location = new System.Drawing.Point(370, 37);
            this.lGet.Name = "lGet";
            this.lGet.Size = new System.Drawing.Size(31, 17);
            this.lGet.TabIndex = 5;
            this.lGet.Text = "unit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 148);
            this.Controls.Add(this.lGet);
            this.Controls.Add(this.lSet);
            this.Controls.Add(this.cbGet);
            this.Controls.Add(this.cbSet);
            this.Controls.Add(this.tbGet);
            this.Controls.Add(this.tbSet);
            this.Name = "MainForm";
            this.Text = "LesApp2 (Temperature converter)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSet;
        private System.Windows.Forms.TextBox tbGet;
        private System.Windows.Forms.ComboBox cbSet;
        private System.Windows.Forms.ComboBox cbGet;
        private System.Windows.Forms.Label lSet;
        private System.Windows.Forms.Label lGet;
    }
}

