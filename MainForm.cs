using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForestComp
{
	public partial class MainForm : Form
	{
		
		Board board;
		private int ticks;
		private int count = 0;

		public MainForm()
		{
			InitializeComponent();
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			modeltimer.Start();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

			board = new Board(this);
			button2.BackColor = Color.FromArgb(120, 200, 0);
			button2.FlatStyle = FlatStyle.Flat;
			button2.FlatAppearance.BorderColor = Color.FromArgb(120, 200, 0);

			button3.BackColor = Color.FromArgb(24, 144, 248);
			button3.FlatStyle = FlatStyle.Flat;
			button3.FlatAppearance.BorderColor = Color.FromArgb(24, 144, 248);

			button4.BackColor = Color.FromArgb(48, 80, 0);
			button4.FlatStyle = FlatStyle.Flat;
			button4.FlatAppearance.BorderColor = Color.FromArgb(48, 80, 0);

			button5.BackColor = Color.FromArgb(209, 137, 81);
			button5.FlatStyle = FlatStyle.Flat;
			button5.FlatAppearance.BorderColor = Color.FromArgb(209, 137, 81);

			button6.BackColor = Color.FromArgb(208, 156, 122);
			button6.FlatStyle = FlatStyle.Flat;
			button6.FlatAppearance.BorderColor = Color.FromArgb(208, 156, 122);

			button7.BackColor = Color.FromArgb(208, 176, 132);
			button7.FlatStyle = FlatStyle.Flat;
			button7.FlatAppearance.BorderColor = Color.FromArgb(208, 176, 132);

			button8.BackColor = Color.FromArgb(248, 120, 0);
			button8.FlatStyle = FlatStyle.Flat;
			button8.FlatAppearance.BorderColor = Color.FromArgb(248, 120, 0);

			button9.BackColor = Color.FromArgb(124, 124, 124);
			button9.FlatStyle = FlatStyle.Flat;
			button9.FlatAppearance.BorderColor = Color.FromArgb(124, 124, 124);
		}

		

		private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void oneyear_button_Click(object sender, EventArgs e)
        {
			board.oneyear_step();
			count++;
			this.label12.Text = count.ToString();
		}

        private void modeltimer_Tick(object sender, EventArgs e)
        {
			ticks++;
			

			if ((ticks / 5) == 0)
            {
				board.oneyear_step();
				count++;
				this.label12.Text = count.ToString();
				ticks = 0;
			}

        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
			modeltimer.Stop();
		}

        private void firecheckBox_CheckedChanged(object sender, EventArgs e)
        {
			if (this.firecheckBox.Checked)
			{
				board.firebutton_flag = true;
			}
			if (!this.firecheckBox.Checked)
				board.firebutton_flag = false;

		}

		private void fiveyears_button_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 5; i++)
			{
				board.oneyear_step();
				count++;

			}
			this.label12.Text = count.ToString();
		}

        private void restart_button_Click(object sender, EventArgs e)
        {
			board.remove_board();
			board = new Board(this);
			count = 0;
		}
    }
}
