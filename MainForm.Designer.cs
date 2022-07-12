
namespace ForestComp
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.oneyear_button = new System.Windows.Forms.Button();
            this.luminetextBox = new System.Windows.Forms.TextBox();
            this.wetnesstextBox = new System.Windows.Forms.TextBox();
            this.luminelabel = new System.Windows.Forms.Label();
            this.wetlabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.firebutton = new System.Windows.Forms.Button();
            this.stopbutton = new System.Windows.Forms.Button();
            this.modeltimer = new System.Windows.Forms.Timer(this.components);
            this.firecheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Запустить ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(205, 343);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // oneyear_button
            // 
            this.oneyear_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oneyear_button.Location = new System.Drawing.Point(12, 390);
            this.oneyear_button.Name = "oneyear_button";
            this.oneyear_button.Size = new System.Drawing.Size(205, 58);
            this.oneyear_button.TabIndex = 2;
            this.oneyear_button.Text = "Шаг: 1 год";
            this.oneyear_button.UseVisualStyleBackColor = true;
            this.oneyear_button.Click += new System.EventHandler(this.oneyear_button_Click);
            // 
            // luminetextBox
            // 
            this.luminetextBox.Location = new System.Drawing.Point(80, 5);
            this.luminetextBox.Name = "luminetextBox";
            this.luminetextBox.Size = new System.Drawing.Size(112, 20);
            this.luminetextBox.TabIndex = 3;
            this.luminetextBox.TextChanged += new System.EventHandler(this.luminetextBox_TextChanged);
            // 
            // wetnesstextBox
            // 
            this.wetnesstextBox.Location = new System.Drawing.Point(80, 87);
            this.wetnesstextBox.Name = "wetnesstextBox";
            this.wetnesstextBox.Size = new System.Drawing.Size(112, 20);
            this.wetnesstextBox.TabIndex = 4;
            // 
            // luminelabel
            // 
            this.luminelabel.AutoSize = true;
            this.luminelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.luminelabel.Location = new System.Drawing.Point(3, 5);
            this.luminelabel.Name = "luminelabel";
            this.luminelabel.Size = new System.Drawing.Size(51, 20);
            this.luminelabel.TabIndex = 5;
            this.luminelabel.Text = "Свет:";
            // 
            // wetlabel
            // 
            this.wetlabel.AutoSize = true;
            this.wetlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wetlabel.Location = new System.Drawing.Point(3, 87);
            this.wetlabel.Name = "wetlabel";
            this.wetlabel.Size = new System.Drawing.Size(70, 20);
            this.wetlabel.TabIndex = 6;
            this.wetlabel.Text = "Осадки:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.firecheckBox);
            this.panel1.Controls.Add(this.firebutton);
            this.panel1.Controls.Add(this.luminetextBox);
            this.panel1.Controls.Add(this.wetlabel);
            this.panel1.Controls.Add(this.luminelabel);
            this.panel1.Controls.Add(this.wetnesstextBox);
            this.panel1.Location = new System.Drawing.Point(15, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 182);
            this.panel1.TabIndex = 7;
            // 
            // firebutton
            // 
            this.firebutton.Location = new System.Drawing.Point(108, 44);
            this.firebutton.Name = "firebutton";
            this.firebutton.Size = new System.Drawing.Size(112, 23);
            this.firebutton.TabIndex = 7;
            this.firebutton.Text = "Запуск пожара";
            this.firebutton.UseVisualStyleBackColor = true;
            this.firebutton.Click += new System.EventHandler(this.firebutton_Click);
            // 
            // stopbutton
            // 
            this.stopbutton.Location = new System.Drawing.Point(113, 12);
            this.stopbutton.Name = "stopbutton";
            this.stopbutton.Size = new System.Drawing.Size(104, 23);
            this.stopbutton.TabIndex = 8;
            this.stopbutton.Text = "Стоп";
            this.stopbutton.UseVisualStyleBackColor = true;
            this.stopbutton.Click += new System.EventHandler(this.stopbutton_Click);
            // 
            // modeltimer
            // 
            this.modeltimer.Tick += new System.EventHandler(this.modeltimer_Tick);
            // 
            // firecheckBox
            // 
            this.firecheckBox.AutoSize = true;
            this.firecheckBox.Location = new System.Drawing.Point(3, 48);
            this.firecheckBox.Name = "firecheckBox";
            this.firecheckBox.Size = new System.Drawing.Size(102, 17);
            this.firecheckBox.TabIndex = 8;
            this.firecheckBox.Text = "Режим пожара";
            this.firecheckBox.UseVisualStyleBackColor = true;
            this.firecheckBox.CheckedChanged += new System.EventHandler(this.firecheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 703);
            this.Controls.Add(this.stopbutton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.oneyear_button);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Button oneyear_button;
        public System.Windows.Forms.TextBox luminetextBox;
        public System.Windows.Forms.TextBox wetnesstextBox;
        private System.Windows.Forms.Label luminelabel;
        private System.Windows.Forms.Label wetlabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button stopbutton;
        private System.Windows.Forms.Timer modeltimer;
        public System.Windows.Forms.Button firebutton;
        public System.Windows.Forms.CheckBox firecheckBox;
    }
}

