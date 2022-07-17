
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
            this.firecheckBox = new System.Windows.Forms.CheckBox();
            this.restart_button = new System.Windows.Forms.Button();
            this.stopbutton = new System.Windows.Forms.Button();
            this.modeltimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fiveyears_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(10, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Запустить симуляцию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(7, 218);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(229, 203);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // oneyear_button
            // 
            this.oneyear_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oneyear_button.Location = new System.Drawing.Point(7, 427);
            this.oneyear_button.Name = "oneyear_button";
            this.oneyear_button.Size = new System.Drawing.Size(108, 41);
            this.oneyear_button.TabIndex = 2;
            this.oneyear_button.Text = "Шаг: 1 год";
            this.oneyear_button.UseVisualStyleBackColor = true;
            this.oneyear_button.Click += new System.EventHandler(this.oneyear_button_Click);
            // 
            // luminetextBox
            // 
            this.luminetextBox.Location = new System.Drawing.Point(119, 12);
            this.luminetextBox.Name = "luminetextBox";
            this.luminetextBox.Size = new System.Drawing.Size(96, 20);
            this.luminetextBox.TabIndex = 3;
            // 
            // wetnesstextBox
            // 
            this.wetnesstextBox.Location = new System.Drawing.Point(119, 44);
            this.wetnesstextBox.Name = "wetnesstextBox";
            this.wetnesstextBox.Size = new System.Drawing.Size(96, 20);
            this.wetnesstextBox.TabIndex = 4;
            // 
            // luminelabel
            // 
            this.luminelabel.AutoSize = true;
            this.luminelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.luminelabel.Location = new System.Drawing.Point(33, 12);
            this.luminelabel.Name = "luminelabel";
            this.luminelabel.Size = new System.Drawing.Size(51, 20);
            this.luminelabel.TabIndex = 5;
            this.luminelabel.Text = "Свет:";
            // 
            // wetlabel
            // 
            this.wetlabel.AutoSize = true;
            this.wetlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wetlabel.Location = new System.Drawing.Point(14, 42);
            this.wetlabel.Name = "wetlabel";
            this.wetlabel.Size = new System.Drawing.Size(70, 20);
            this.wetlabel.TabIndex = 6;
            this.wetlabel.Text = "Осадки:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.firecheckBox);
            this.panel1.Controls.Add(this.restart_button);
            this.panel1.Controls.Add(this.luminetextBox);
            this.panel1.Controls.Add(this.wetlabel);
            this.panel1.Controls.Add(this.luminelabel);
            this.panel1.Controls.Add(this.wetnesstextBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.stopbutton);
            this.panel1.Location = new System.Drawing.Point(2, 474);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 208);
            this.panel1.TabIndex = 7;
            // 
            // firecheckBox
            // 
            this.firecheckBox.AutoSize = true;
            this.firecheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firecheckBox.Location = new System.Drawing.Point(10, 74);
            this.firecheckBox.Name = "firecheckBox";
            this.firecheckBox.Size = new System.Drawing.Size(122, 20);
            this.firecheckBox.TabIndex = 8;
            this.firecheckBox.Text = "Режим пожара";
            this.firecheckBox.UseVisualStyleBackColor = true;
            this.firecheckBox.CheckedChanged += new System.EventHandler(this.firecheckBox_CheckedChanged);
            // 
            // restart_button
            // 
            this.restart_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.restart_button.Location = new System.Drawing.Point(10, 176);
            this.restart_button.Name = "restart_button";
            this.restart_button.Size = new System.Drawing.Size(205, 29);
            this.restart_button.TabIndex = 15;
            this.restart_button.Text = "Начать заново";
            this.restart_button.UseVisualStyleBackColor = true;
            this.restart_button.Click += new System.EventHandler(this.restart_button_Click);
            // 
            // stopbutton
            // 
            this.stopbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopbutton.Location = new System.Drawing.Point(10, 138);
            this.stopbutton.Name = "stopbutton";
            this.stopbutton.Size = new System.Drawing.Size(205, 32);
            this.stopbutton.TabIndex = 8;
            this.stopbutton.Text = "Пауза";
            this.stopbutton.UseVisualStyleBackColor = true;
            this.stopbutton.Click += new System.EventHandler(this.stopbutton_Click);
            // 
            // modeltimer
            // 
            this.modeltimer.Tick += new System.EventHandler(this.modeltimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(19, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // fiveyears_button
            // 
            this.fiveyears_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fiveyears_button.Location = new System.Drawing.Point(121, 427);
            this.fiveyears_button.Name = "fiveyears_button";
            this.fiveyears_button.Size = new System.Drawing.Size(115, 41);
            this.fiveyears_button.TabIndex = 10;
            this.fiveyears_button.Text = "Шаг: 5 лет";
            this.fiveyears_button.UseVisualStyleBackColor = true;
            this.fiveyears_button.Click += new System.EventHandler(this.fiveyears_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(420, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Схема участка леса (стволы деревьев)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(925, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Схема участка леса (кроны деревьев)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 32);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(242, 631);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 51);
            this.panel2.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(946, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = " <- Пепел";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(912, 11);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(34, 32);
            this.button9.TabIndex = 27;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(839, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = " <- Огонь";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(805, 11);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(34, 32);
            this.button8.TabIndex = 25;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(683, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = " <- Бедная почва";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(649, 11);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(34, 32);
            this.button7.TabIndex = 23;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(515, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = " <- Средняя почва";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(480, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(34, 32);
            this.button6.TabIndex = 21;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(355, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = " <- Богатая почва";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(320, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(34, 32);
            this.button5.TabIndex = 19;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(257, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = " <- Ель";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(223, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 32);
            this.button4.TabIndex = 17;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(152, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = " <- Клён";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(116, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 32);
            this.button3.TabIndex = 15;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(44, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = " <- Осина";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(247, 603);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(365, 18);
            this.label11.TabIndex = 9;
            this.label11.Text = "Время существования модели ( в условных годах):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(619, 604);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 18);
            this.label12.TabIndex = 10;
            this.label12.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 684);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fiveyears_button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.oneyear_button);
            this.Controls.Add(this.richTextBox1);
            this.Name = "MainForm";
            this.Text = "ForestModel";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        public System.Windows.Forms.CheckBox firecheckBox;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button fiveyears_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button restart_button;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}

