using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ForestComp
{
	public class Board
	{
		public static MainForm window;
		public static Cell[,] buttons;
		public static Aircells[,] buttons2;
		public static Random rand = new Random();
		int n = 35; //Размер поля для отрисовки 

		public Board(MainForm board)
		{
			window = board;

			buttons = new Cell[n, n];
			buttons2 = new Aircells[n, n];

			//Формирование полей с клетками
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Cell button = new Cell();
					Aircells button2 = new Aircells();

					button.Location = new Point(250 + i * 15, 42 + j * 15);
					button2.Location = new Point(800 + i * 15, 42 + j * 15);

					button.FlatStyle = FlatStyle.Flat;
					button.FlatAppearance.BorderColor = Color.LightGray;
					button2.FlatStyle = FlatStyle.Flat;
					button2.FlatAppearance.BorderColor = Color.LightGray;
					
					soil_Choose(button);	//Генерация почвы
					window.Controls.Add(button);
					window.Controls.Add(button2);
					buttons[i, j] = button;
					buttons2[i, j] = button2;

					if ((i > 1 && j > 1 && i < (n - 2) && j < (n - 2)))
						plant_Choose(buttons[i, j]);

					buttons[i, j].Click += new EventHandler(buttons_Click);
					buttons2[i, j].Click += new EventHandler(buttons2_Click);
				}


			}

			//Отрисовка кроны деревьев 
			for (int i = 1; i < (n - 1); i++)
			{
				for (int j = 1; j < (n - 1); j++)
				{
					if (buttons[i, j].plants.plantkind != PlantKind.Empty)
						crown_Draw(buttons2, buttons[i, j], i, j);
				}
			}
		}

		private void buttons_Click(object sender, EventArgs e)
		{
			Cell pressedKletka = sender as Cell;
			window.richTextBox1.Text += pressedKletka.plants.plantkind + " ";
			window.richTextBox1.Text += pressedKletka.soil.soilkind + "\n";
			window.richTextBox1.Text += "Age = " + pressedKletka.plants.age + "\n";
			window.richTextBox1.Text += "Height = " + pressedKletka.plants.height + "\n";
			plant_Placement(pressedKletka);
		}

		private void buttons2_Click(object sender, EventArgs e)
		{
			Aircells pressedKletka = sender as Aircells;
			window.richTextBox1.Text += pressedKletka.plkolvo + " ";
            for (int i = 0; i < pressedKletka.plkolvo; i++)
                window.richTextBox1.Text += pressedKletka.plants[i].plantkind + "\n";


            //window.richTextBox1.Text += "Age = " + pressedKletka.plants.age + "\n";
            //window.richTextBox1.Text += "Height = " + pressedKletka.plants[int].height + "\n";
            //plant_Placement(pressedKletka);
        }
		public void oneyear_step()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (buttons[i, j].plants.plantkind != PlantKind.Empty)
					{
						buttons[i, j].plants.age += 1;					
						plant_grow(buttons[i, j]);
						crown_check();
					}
				}
			}
		}

		private void plant_Choose(Cell kletka)
		{
			int random_plant = plant_Placement(kletka);
			//int random_plant = rand.Next(1, 101);
			//window.richTextBox1.Text += random_plant + "\n";
			switch (random_plant)
			{
				case 1:
					{
						kletka.plants = new Osina();
						// kletka.plants.plantkind = PlantKind.Osina;
						kletka.plants.plantstage = PlantStage.Normal;
						kletka.BackColor = kletka.plants.trunkColor;
						break;
					}
				case 2:
					{
						kletka.plants = new El();
						kletka.plants.plantkind = PlantKind.El;
						kletka.plants.plantstage = PlantStage.Normal;
						kletka.BackColor = kletka.plants.trunkColor;
						break;
					}
				case 3:
					{
						kletka.plants = new Klen();
						kletka.plants.plantkind = PlantKind.Klen;
						kletka.plants.plantstage = PlantStage.Small;
						kletka.BackColor = kletka.plants.trunkColor;
						break;
					}
				default:
					{
						break;
					}
			}

		}

		private void soil_Choose(Cell kletka)
		{
			int random_soil = rand.Next(1, 5);

			switch (random_soil)
			{
				case 1:
				case 4:
					{
						kletka.soil = new Poor();
						kletka.BackColor = kletka.soil.soilColor;

						break;
					}
				case 2:
					{
						kletka.soil = new Average();
						kletka.BackColor = kletka.soil.soilColor;

						break;
					}
				case 3:
					{
						kletka.soil = new Rich();
						kletka.BackColor = kletka.soil.soilColor;

						break;
					}
				default:
					{
						break;
					}
			}

		}

		//Спавн деревьев
		private int plant_Placement(Cell kletka)
		{
			int kolvo = 101;

			int[] rand_mass = new int[kolvo];
			for (int i = 0; i < kolvo; i++)
				rand_mass[i] = 0;

			int[] plant_soil = new int[6]; //Массив для хранения требований к почве разных растений

			Osina osina = new Osina();
			Klen klen = new Klen();
			El el = new El();

			plant_soil[0] = kletka.soil.prolificacy - osina.soil_demand;
			plant_soil[1] = kletka.soil.prolificacy - klen.soil_demand;
			plant_soil[2] = kletka.soil.prolificacy - el.soil_demand;

			int osina_chances = 3, klen_chances = 2, el_chances = 2;

			//Шансы деревьев прорасти при заданной плодородности
			if (Math.Abs(plant_soil[0]) <= 10)
				osina_chances += 0;
			else if (plant_soil[0] > 10 && plant_soil[0] <= 30)
				osina_chances += 1;
			else if (plant_soil[0] > 30 && plant_soil[0] <= 60)
				osina_chances += 2;
			else if (plant_soil[0] > 60)
				osina_chances += 3;
			else if (plant_soil[0] < -10 && plant_soil[0] >= -30)
				osina_chances -= 1;
			else if (plant_soil[0] < -30 && plant_soil[0] >= -60)
				osina_chances -= 2;
			else if (plant_soil[0] < -60)
				osina_chances -= 3;

			if (Math.Abs(plant_soil[1]) <= 10)
				klen_chances += 0;
			else if (plant_soil[1] > 10 && plant_soil[1] <= 30)
				klen_chances += 1;
			else if (plant_soil[1] > 30 && plant_soil[1] <= 60)
				klen_chances += 2;
			else if (plant_soil[1] > 60)
				klen_chances += 3;
			else if (plant_soil[1] < -10 && plant_soil[1] >= -30)
				klen_chances -= 1;
			else if (plant_soil[1] < -30 && plant_soil[1] >= -60)
				klen_chances -= 2;
			else if (plant_soil[1] < -60)
				klen_chances -= 3;

			if (Math.Abs(plant_soil[2]) <= 10)
				el_chances += 0;
			else if (plant_soil[2] > 10 && plant_soil[2] <= 30)
				el_chances += 1;
			else if (plant_soil[2] > 30 && plant_soil[2] <= 60)
				el_chances += 2;
			else if (plant_soil[2] > 60)
				el_chances += 3;
			else if (plant_soil[2] < -10 && plant_soil[2] >= -30)
				el_chances -= 1;
			else if (plant_soil[2] < -30 && plant_soil[2] >= -60)
				el_chances -= 2;
			else if (plant_soil[2] < -60)
				el_chances -= 3;

			//Шансы деревьев прорасти при заданной влажности почвы
			plant_soil[3] = kletka.soil.wetness - osina.water_demand;
			plant_soil[4] = kletka.soil.wetness - klen.water_demand;
			plant_soil[5] = kletka.soil.wetness - el.water_demand;

			if (Math.Abs(plant_soil[3]) <= 10)
				osina_chances += 2;
			else if (Math.Abs(plant_soil[3]) > 10 && Math.Abs(plant_soil[3]) <= 30)
				osina_chances += 1;
			else if (Math.Abs(plant_soil[3]) > 30 && Math.Abs(plant_soil[3]) <= 60)
				osina_chances -= 2;
			else if (Math.Abs(plant_soil[3]) > 60)
				osina_chances -= 3;


			if (Math.Abs(plant_soil[4]) <= 10)
				klen_chances += 2;
			else if (Math.Abs(plant_soil[4]) > 10 && Math.Abs(plant_soil[4]) <= 30)
				klen_chances += 1;
			else if (Math.Abs(plant_soil[4]) > 30 && Math.Abs(plant_soil[4]) <= 60)
				klen_chances -= 2;
			else if (Math.Abs(plant_soil[4]) > 60)
				klen_chances -= 3;


			if (Math.Abs(plant_soil[5]) <= 10)
				el_chances += 2;
			else if (Math.Abs(plant_soil[5]) > 10 && Math.Abs(plant_soil[5]) <= 30)
				el_chances += 1;
			else if (Math.Abs(plant_soil[5]) > 30 && Math.Abs(plant_soil[5]) <= 60)
				el_chances -= 1;
			else if (Math.Abs(plant_soil[5]) > 60)
				el_chances -= 2;

			//Добавление в массив вероятности 
			for (int i = 0; i < osina_chances; i++)
				rand_mass[i] = 1;

			for (int i = osina_chances; i < osina_chances + klen_chances; i++)
				rand_mass[i] = 2;

			for (int i = osina_chances + klen_chances; i < osina_chances + klen_chances + el_chances; i++)
				rand_mass[i] = 3;

			int random_pl = rand_mass[rand.Next(0, rand_mass.Length)];
			return random_pl;


			//window.richTextBox1.Text += "Osina chances = " + osina_chances + "\n";
			//window.richTextBox1.Text += "Klen chances = " + klen_chances + "\n";
			//window.richTextBox1.Text += "El chances = " + el_chances + "\n";
			//window.richTextBox1.Text += "\n";
			//int rand_plant = rand.Next(1, prolifc_req);

		}

		private void crown_Draw(Aircells[,] aircells, Cell kletka, int i, int j)
		{
			int k = i;
			switch (kletka.plants.plantstage)
			{
				case PlantStage.Small:
					{
						aircells[i, j].plants[aircells[i, j].plkolvo] = kletka.plants;
						aircells[i, j].plkolvo++;
						aircells[i, j].BackColor = kletka.plants.crownColor;
                        break;
					}
				case PlantStage.Normal:
					{
						
						aircells[i, j].plants[aircells[i, j].plkolvo] = kletka.plants;
                        aircells[i + 1, j].plants[aircells[i + 1, j].plkolvo] = kletka.plants;
                        aircells[i - 1, j].plants[aircells[i - 1, j].plkolvo] = kletka.plants;
                        aircells[i, j + 1].plants[aircells[i, j + 1].plkolvo] = kletka.plants;
                        aircells[i, j - 1].plants[aircells[i, j - 1].plkolvo] = kletka.plants;

                        aircells[i, j].BackColor = kletka.plants.crownColor;
						aircells[i + 1, j].BackColor = kletka.plants.crownColor;
						aircells[i - 1, j].BackColor = kletka.plants.crownColor;
						aircells[i, j + 1].BackColor = kletka.plants.crownColor;
						aircells[i, j - 1].BackColor = kletka.plants.crownColor;
						
						aircells[i, j].plkolvo++;
						aircells[i + 1, j].plkolvo++;
						aircells[i - 1, j].plkolvo++;
						aircells[i, j + 1].plkolvo++;
						aircells[i, j - 1].plkolvo++;
						break;
					}
				case PlantStage.Big:
					{
						aircells[i, j].BackColor = kletka.plants.crownColor;
						aircells[i + 1, j].BackColor = kletka.plants.crownColor;
						aircells[i + 2, j].BackColor = kletka.plants.crownColor;
						aircells[i - 1, j].BackColor = kletka.plants.crownColor;
						aircells[i - 2, j].BackColor = kletka.plants.crownColor;

						aircells[i, j - 1].BackColor = kletka.plants.crownColor;
						aircells[i, j - 2].BackColor = kletka.plants.crownColor;
						aircells[i, j + 1].BackColor = kletka.plants.crownColor;
						aircells[i, j + 2].BackColor = kletka.plants.crownColor;

						aircells[i + 1, j + 1].BackColor = kletka.plants.crownColor;
						aircells[i + 1, j - 1].BackColor = kletka.plants.crownColor;
						aircells[i - 1, j + 1].BackColor = kletka.plants.crownColor;
						aircells[i - 1, j - 1].BackColor = kletka.plants.crownColor;
						break;
					}
				default:
					{

						break;
					}
			}
		}

		//Рост деревьев
		private void plant_grow(Cell kletka)
		{
			double modif = growth_modificator(kletka);

			if (kletka.plants.age <= 1 && kletka.plants.plantkind == PlantKind.Osina && kletka.plants.height < 40)
			{
				kletka.plants.height += 2 * modif;
			}
			else if (kletka.plants.age > 1 && kletka.plants.age < 40 && kletka.plants.plantkind == PlantKind.Osina && kletka.plants.height < 40)
			{
				kletka.plants.height += 1 * modif;
			}


			if (kletka.plants.age <= 3 && kletka.plants.plantkind == PlantKind.Klen && kletka.plants.height < 25)
			{
				kletka.plants.height += 1 * modif;
			}
			else if (kletka.plants.age > 1 && kletka.plants.age < 25 && kletka.plants.plantkind == PlantKind.Klen && kletka.plants.height < 25)
			{
				kletka.plants.height += 0.5 * modif;
			}


			if (kletka.plants.age <= 15 && kletka.plants.plantkind == PlantKind.El && kletka.plants.height < 35)
			{
				kletka.plants.height += 0.2 * modif;
			}
			else if (kletka.plants.age > 15 && kletka.plants.age < 60 && kletka.plants.plantkind == PlantKind.El && kletka.plants.height < 35)
			{
				kletka.plants.height += 0.5 * modif;
			}

		}


		private double growth_modificator(Cell kletka)
		{

			double modif = 0;
			int plant_soil = kletka.soil.prolificacy - kletka.plants.soil_demand;
			int plant_water = kletka.soil.wetness - kletka.plants.water_demand;
			int plant_light = kletka.illumination - kletka.plants.light_demand;
			int soil_toxity = kletka.soil.toxity;

			//Шансы деревьев прорасти при заданной плодородности
			if (Math.Abs(plant_soil) <= 10)
				modif += 0.3;
			else if (plant_soil > 10 && plant_soil <= 30)
				modif += 0.4;
			else if (plant_soil > 30)
				modif += 0.5;
			else if (plant_soil < -10 && plant_soil >= -30)
				modif -= 0.3;
			else if (plant_soil < -30 && plant_soil >= -60)
				modif -= 0.4;
			else if (plant_soil < -60)
			{
				kletka.plants.lifepoints -= 10;
				modif -= 0.5;
			}

			if (Math.Abs(plant_water) <= 10)
				modif += 0.3;
			else if (Math.Abs(plant_water) > 10 && Math.Abs(plant_water) <= 30)
				modif += 0.4;
			else if (Math.Abs(plant_water) > 30 && Math.Abs(plant_water) <= 60)
				modif -= 0.3;
			else if (Math.Abs(plant_water) > 60)
			{
				kletka.plants.lifepoints -= 10;
				modif -= 0.4;
			}

			if (Math.Abs(plant_light) <= 10)
			{
				if (kletka.plants.plantkind == PlantKind.El)
					modif += 0.3;
				else
					modif += 0.4;
			}
			else if (Math.Abs(plant_light) > 10 && Math.Abs(plant_light) <= 30)
			{
				if (kletka.plants.plantkind == PlantKind.El)
					modif += 0.2;
				else
					modif += 0.3;
			}
			else if (Math.Abs(plant_light) > 30 && Math.Abs(plant_light) <= 60)
			{
				if (kletka.plants.plantkind == PlantKind.El)
					modif -= 0.2;
				else
					modif -= 0.3;
			}
			else if (Math.Abs(plant_light) > 60)
			{
				kletka.plants.lifepoints -= 10;

				if (kletka.plants.plantkind == PlantKind.El)
					modif -= 0.3;
				else
					modif -= 0.4;
			}


			if (modif < 0)
			{
				modif = 0;
			}
			return modif;

		}

		//Если дерево выше, на поле его крона будет отображаться поверх других при пересечении клеток
		private void crown_check()
		{
			
			for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
					if (buttons2[i, j].plkolvo > 1)
					{					
						double max = -1;
						int maxindex = -1;

						max = buttons2[i, j].plants[0].height;

						for (int k = 0; k < buttons2[i, j].plkolvo; k++)
						{
							if (max <= buttons2[i, j].plants[k].height)
								maxindex = k;
						}
						
						buttons2[i, j].BackColor = buttons2[i, j].plants[maxindex].crownColor;

					}
                }
            }
        }
	}
}
