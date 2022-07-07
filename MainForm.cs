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
		Cell[,] buttons;
		Button[,] buttons2;
		Random rand = new Random();
		public MainForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void MainForm_Load(object sender, EventArgs e)
		{

			buttons = new Cell[32, 32];
			buttons2 = new Button[32, 32];

			//Формирование полей с клетками
			for (int i = 0; i < 32; i++)
			{
				for (int j = 0; j < 32; j++)
				{
					Cell button = new Cell(/*j, i*/);
					Button button2 = new Button();
					//button.Size = new Size(15, 15);
					button2.Size = new Size(15, 15);

					button.Location = new Point(120 + i * 15, 42 + j * 15);
					button2.Location = new Point(730 + i * 15, 42 + j * 15);

					button.FlatStyle = FlatStyle.Flat;
					button.FlatAppearance.BorderColor = Color.LightGray;
					
					int r = rand.Next(1, 5);

					if (r == 1)
						{ button.BackColor = Color.FromArgb(208, 176, 132);
						button2.BackColor = Color.FromArgb(208, 176, 132);
					}
					else
						{ button.BackColor = Color.FromArgb(218, 189, 171);
						button2.BackColor = Color.FromArgb(218, 189, 171);
					}

					button2.FlatStyle = FlatStyle.Flat;
					button2.FlatAppearance.BorderColor = Color.LightGray;

					Controls.Add(button);
					Controls.Add(button2);
					buttons[i, j] = button;
					buttons2[i, j] = button2;

					r = rand.Next(1, 41);

					//Случайная отрисовка деревьев
					if (i != 0 && j != 0 && i != 31 && j != 31 && r == 1)
					{   
						buttons[i, j].BackColor = Color.White;
					}
				}

			}

			//Отрисовка кроны деревьев 
			for (int i = 1; i < 31; i++)
			{
				for (int j = 1; j < 31; j++)
				{
					if (buttons[i, j].BackColor == Color.White)
					{
						buttons2[i, j].BackColor = Color.ForestGreen;
						buttons2[i + 1, j].BackColor = Color.ForestGreen;
						buttons2[i - 1, j].BackColor = Color.ForestGreen;
						buttons2[i, j + 1].BackColor = Color.ForestGreen;
						buttons2[i, j - 1].BackColor = Color.ForestGreen;
						
					}
				}
			}

		}
	}
}
