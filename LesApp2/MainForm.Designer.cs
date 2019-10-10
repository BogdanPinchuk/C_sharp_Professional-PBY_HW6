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
            this.components = new System.ComponentModel.Container();
            this.tbSet = new System.Windows.Forms.TextBox();
            this.tbGet = new System.Windows.Forms.TextBox();
            this.cbSet = new System.Windows.Forms.ComboBox();
            this.cbGet = new System.Windows.Forms.ComboBox();
            this.lSet = new System.Windows.Forms.Label();
            this.lGet = new System.Windows.Forms.Label();
            this.ttHelp = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSet
            // 
            this.tbSet.Location = new System.Drawing.Point(9, 28);
            this.tbSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSet.Name = "tbSet";
            this.tbSet.Size = new System.Drawing.Size(111, 20);
            this.tbSet.TabIndex = 0;
            this.tbSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ttHelp.SetToolTip(this.tbSet, "Input degree");
            this.tbSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSet_KeyPress);
            // 
            // tbGet
            // 
            this.tbGet.Location = new System.Drawing.Point(163, 28);
            this.tbGet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbGet.Name = "tbGet";
            this.tbGet.ReadOnly = true;
            this.tbGet.Size = new System.Drawing.Size(111, 20);
            this.tbGet.TabIndex = 1;
            this.tbGet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ttHelp.SetToolTip(this.tbGet, "Output degree");
            // 
            // cbSet
            // 
            this.cbSet.FormattingEnabled = true;
            this.cbSet.Location = new System.Drawing.Point(9, 71);
            this.cbSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSet.Name = "cbSet";
            this.cbSet.Size = new System.Drawing.Size(111, 21);
            this.cbSet.TabIndex = 2;
            this.ttHelp.SetToolTip(this.cbSet, "Input temperature scale");
            // 
            // cbGet
            // 
            this.cbGet.FormattingEnabled = true;
            this.cbGet.Location = new System.Drawing.Point(163, 71);
            this.cbGet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbGet.Name = "cbGet";
            this.cbGet.Size = new System.Drawing.Size(111, 21);
            this.cbGet.TabIndex = 3;
            this.ttHelp.SetToolTip(this.cbGet, "Output temperature scale");
            // 
            // lSet
            // 
            this.lSet.AutoSize = true;
            this.lSet.Location = new System.Drawing.Point(124, 30);
            this.lSet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lSet.Name = "lSet";
            this.lSet.Size = new System.Drawing.Size(24, 13);
            this.lSet.TabIndex = 4;
            this.lSet.Text = "unit";
            this.ttHelp.SetToolTip(this.lSet, "Input units");
            // 
            // lGet
            // 
            this.lGet.AutoSize = true;
            this.lGet.Location = new System.Drawing.Point(278, 30);
            this.lGet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lGet.Name = "lGet";
            this.lGet.Size = new System.Drawing.Size(24, 13);
            this.lGet.TabIndex = 5;
            this.lGet.Text = "unit";
            this.ttHelp.SetToolTip(this.lGet, "Output units");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 168);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(337, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slInfo
            // 
            this.slInfo.Name = "slInfo";
            this.slInfo.Size = new System.Drawing.Size(98, 17);
            this.slInfo.Text = "Help information";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 190);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lGet);
            this.Controls.Add(this.lSet);
            this.Controls.Add(this.cbGet);
            this.Controls.Add(this.cbSet);
            this.Controls.Add(this.tbGet);
            this.Controls.Add(this.tbSet);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "LesApp2 (Temperature converter)";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolTip ttHelp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slInfo;
    }
}

