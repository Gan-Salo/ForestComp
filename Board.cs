using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ForestComp
{
	class Board
	{
		public static MainForm window;
		public static Cell[,] buttons;
		public static Button[,] buttons2;
		public static Random rand = new Random();
		int n = 35; //Размер поля для отрисовки 

		public Board(MainForm board)
		{
			window = board;

			buttons = new Cell[n, n];
			buttons2 = new Button[n, n];

			//Формирование полей с клетками
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Cell button = new Cell();
					Button button2 = new Button();
					//button.Size = new Size(15, 15);
					button2.Size = new Size(15, 15);

					button.Location = new Point(250 + i * 15, 42 + j * 15);
					button2.Location = new Point(800 + i * 15, 42 + j * 15);

					button.FlatStyle = FlatStyle.Flat;
					button.FlatAppearance.BorderColor = Color.LightGray;

					int r = rand.Next(1, 5);

					if (r == 1)
					{
						button.BackColor = Color.FromArgb(208, 176, 132);
						button2.BackColor = Color.FromArgb(208, 176, 132);
					}
					else
					{
						button.BackColor = Color.FromArgb(218, 189, 171);
						button2.BackColor = Color.FromArgb(218, 189, 171);
					}

					button2.FlatStyle = FlatStyle.Flat;
					button2.FlatAppearance.BorderColor = Color.LightGray;

					window.Controls.Add(button);
					window.Controls.Add(button2);
					buttons[i, j] = button;
					buttons2[i, j] = button2;

					r = rand.Next(1, 41);

					//Случайная отрисовка деревьев
					if (i != 0 && j != 0 && i != (n - 1) && j != (n - 1) && r == 1)
					{
						buttons[i, j].BackColor = Color.White;
					}

					buttons[i, j].Click += new EventHandler(buttons_Click);
				}


			}

			//Отрисовка кроны деревьев 
			for (int i = 1; i < n; i++)
			{
				for (int j = 1; j < n; j++)
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

		private void buttons_Click(object sender, EventArgs e)
		{
			Cell pressedKletka = sender as Cell;
			window.richTextBox1.Text += pressedKletka.plants.plantkind;
		}
	}
}
