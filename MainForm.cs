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
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void MainForm_Load(object sender, EventArgs e)
		{

			board = new Board(this);

		}

		

		private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
