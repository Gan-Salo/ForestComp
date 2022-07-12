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
		//Cell[,] buttons;
		//Button[,] buttons2;
		//Random rand = new Random();
		Board board;
		private int ticks;

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

		}

		

		private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void oneyear_button_Click(object sender, EventArgs e)
        {
			board.oneyear_step();

		}

        private void luminetextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void modeltimer_Tick(object sender, EventArgs e)
        {
			ticks++;
			this.Text = ticks.ToString();

			if ((ticks / 10) == 0)
            {
				board.oneyear_step();
				ticks = 0;
			}

        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
			modeltimer.Stop();
		}

        public void firebutton_Click(object sender, EventArgs e)
        {

        }

        private void firecheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
