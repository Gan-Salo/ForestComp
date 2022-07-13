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
		public bool firebutton_flag = false;
		public int n = 36; //Размер поля для отрисовки 

		public Board(MainForm board)
		{
			window = board;
			buttons = new Cell[n, n];
			buttons2 = new Aircells[n, n];
			window.luminetextBox.Text = "50";
			window.wetnesstextBox.Text = "50";
			
			//Формирование полей с клетками
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Cell button = new Cell();
					Aircells button2 = new Aircells();

					button.Location = new Point(250 + i * 15, 42 + j * 15);
					button.CoordX = i;
					button.CoordY = j;
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
					buttons2[i, j].BackColor = buttons[i, j].soil.soilColor;

					buttons[i, j].Click += new EventHandler(buttons_Click);				
					buttons2[i, j].Click += new EventHandler(buttons2_Click);
					
				}
			}

			//Отрисовка кроны деревьев 
			for (int i = 2; i < (n - 2); i++)
			{
				for (int j = 2; j < (n - 2); j++)
				{
					
					if (buttons[i, j].plants.plantkind != PlantKind.Empty)
						crown_Draw(buttons2, buttons[i, j], i, j);
				}
			}
		}


		//Удаление текущих полей
		public void remove_board()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					window.Controls.Remove(buttons[i,j]);
					window.Controls.Remove(buttons2[i,j]);
				}
			}
		}
		//Вывод информации при клике на клетку первого поля
		private void buttons_Click(object sender, EventArgs e)
		{
			Cell pressedKletka = sender as Cell;
			
			window.richTextBox1.Clear();
			if (pressedKletka.plants.plantkind == PlantKind.Osina)
			{
				window.pictureBox1.Image = Properties.Resources.osina;
				window.richTextBox1.Text += "Осина " + "\n";
			}
			else if (pressedKletka.plants.plantkind == PlantKind.Klen)
			{
				window.pictureBox1.Image = Properties.Resources.klen;
				window.richTextBox1.Text += "Клён " + "\n";
			}
			else if (pressedKletka.plants.plantkind == PlantKind.El)
			{
				window.pictureBox1.Image = Properties.Resources.el;
				window.richTextBox1.Text += "Ель " + "\n";
			}
			else if (pressedKletka.plants.plantkind == PlantKind.Empty)
			{
				window.pictureBox1.Image = Properties.Resources.none;
				window.richTextBox1.Text += "Поляна " + "\n";
			}

			if (pressedKletka.plants.plantkind != PlantKind.Empty)
			{
				window.richTextBox1.Text += "Возраст дерева: " + pressedKletka.plants.age + "\n";
				window.richTextBox1.Text += "Высота дерева: " + pressedKletka.plants.height + "\n";
				window.richTextBox1.Text += "Стадия роста: " + pressedKletka.plants.plantstage + "\n";
				window.richTextBox1.Text += "Показатель жизни: " + pressedKletka.plants.lifepoints + "\n";
			}
			window.richTextBox1.Text += "Плодородность: " + pressedKletka.soil.prolificacy + " (" + pressedKletka.soil.soilkind + ") \n";
			window.richTextBox1.Text += "Освещённость: " + pressedKletka.illumination + "\n";
			window.richTextBox1.Text += "Влажность: " + pressedKletka.soil.wetness + "\n";
			window.richTextBox1.Text += "Токсичность: " + pressedKletka.soil.toxity + "\n";
			
			if (firebutton_flag == true)
			{
				Fire fire = new Fire(buttons, buttons2, pressedKletka, pressedKletka.CoordX, pressedKletka.CoordY);
			}
		}

		//private void firebutton_Click(object sender, EventArgs e)
		//{
		//	//int i = rand.Next(3, 30);
		//	//int j = rand.Next(3, 30);
		//	for (int i = 1; i < (n - 1); i++)
		//	{
		//		for (int j = 1; j < (n - 1); j++)
		//		{
					
		//		}
		//	}
			
		//}
		
		//Вывод информации при клике на клетку второго поля
		private void buttons2_Click(object sender, EventArgs e)
		{
			Aircells pressedKletka = sender as Aircells;
			
			window.richTextBox1.Clear();
			
			if (pressedKletka.plkolvo == 0)
			{
				window.pictureBox1.Image = Properties.Resources.nokrona; 
				window.richTextBox1.Text += "На этом участке нет кроны " + "\n";
			}

			if (pressedKletka.plkolvo > 0)
			{
				window.pictureBox1.Image = Properties.Resources.krona; 
				window.richTextBox1.Text += "Количество крон на данном участке: " + pressedKletka.plkolvo + "\n";
				
				for (int i = 0; i < pressedKletka.plkolvo; i++)
				{
					if (pressedKletka.plants[i].plantkind == PlantKind.Osina)
					{
						window.richTextBox1.Text += "Осина " + "\n";
					}
					else if (pressedKletka.plants[i].plantkind == PlantKind.Klen)
					{
						window.richTextBox1.Text += "Клён " + "\n";
					}
					else if (pressedKletka.plants[i].plantkind == PlantKind.El)
					{
						window.richTextBox1.Text += "Ель " + "\n";
					}
	
					window.richTextBox1.Text += "Высота дерева:" + pressedKletka.plants[i].height + "\n\n";
				}
			}
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
					if ((i > 2 && j > 2 && i < (n - 3) && j < (n - 3)))
						plant_Choose(buttons[i, j], i, j);

					buttons[i, j].soil.wetness += Convert.ToInt32(window.wetnesstextBox.Text) / 5;
				}
			}
			
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					buttons2[i, j].fireflag = false;
					buttons[i, j].fireflag = false;

					if (buttons[i, j].plants.plantkind == PlantKind.Empty)
					{
						buttons[i, j].soil.wetness -= rand.Next(0, 6) + (buttons[i, j].illumination / 7 /*5*/);
					}
					
					//if (buttons[i, j].soil.prolificacy > 0)
					//	buttons[i, j].soil.prolificacy += 10;
					check_all(buttons[i, j]);


					if (buttons[i, j].plants.plantkind != PlantKind.Empty)
					{
						tree_dead();    //Проверка жизни деревьев и уничтожение мертвых деревьев
						buttons[i, j].plants.age += 1;

						buttons[i, j].soil.wetness -= buttons[i, j].plants.water_demand / 5;    //Почва теряет количество воды, необходимое растению
						
						if (buttons[i, j].plants.plantkind == PlantKind.Klen)
						{
							//for (int i = k - 1; k < i + 1; i++)
							//	for (int l = j - 1; l < j + 1; j++)
							buttons[i, j].soil.toxity += 2;
							buttons[i + 1, j].soil.toxity += 2;
							buttons[i - 1, j].soil.toxity += 2;
							buttons[i, j + 1].soil.toxity += 2;
							buttons[i, j - 1].soil.toxity += 2;
							
						}
						
						plant_grow(buttons[i, j]);  //Отрисовка кроны в зависимости от стадии роста дерева	
						age_check(buttons[i, j]);			
					}
				}
			}

			soil_refresh();     //Обновление почвы
			air_refresh();
			plants_refresh();
			crown_Destroy();
			crown_refresh();
			crown_check();
			lumine_check();
			
		}
		//Спавн деревьев
		public void plant_Choose(Cell kletka, int k, int l)
		{
			int random_plant = plant_Placement(kletka, k, l);
			//int random_plant = rand.Next(1, 101);
			//window.richTextBox1.Text += random_plant + "\n";
			switch (random_plant)
			{
				case 1:
					{
						kletka.plants = new Osina();
						// kletka.plants.plantkind = PlantKind.Osina;
						kletka.plants.plantstage = PlantStage.Small;
						kletka.BackColor = kletka.plants.trunkColor;
						break;
					}
				case 3:
					{
						kletka.plants = new El();
						kletka.plants.plantkind = PlantKind.El;
						kletka.plants.plantstage = PlantStage.Small;
						kletka.BackColor = kletka.plants.trunkColor;
						break;
					}
				case 2:
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

		//Изменяет некорректные значения полей
		public void check_all(Cell kletka)
		{
			if (kletka.soil.wetness < -50)
				kletka.soil.wetness = -50;

			if (kletka.soil.wetness > 120)
				kletka.soil.wetness = 120;

			if (kletka.soil.wetness > 110)
			{
				kletka.soil.toxity -= 1;
			}

			if (kletka.soil.toxity < 0)
			{
				kletka.soil.toxity = 0;
			}

			if (kletka.soil.toxity > 60)
			{
				kletka.soil.toxity = 60;
			}
			
		}
			
		//Размещение почвы
		public void soil_Choose(Cell kletka)
		{
			int random_soil = rand.Next(1, 7);

			switch (random_soil)
			{
				case 1:
				case 2:
				case 3:
					{
						kletka.soil = new Poor();
						kletka.BackColor = kletka.soil.soilColor;
						break;
					}
				case 4:
				case 5:
					{
						kletka.soil = new Average();
						kletka.BackColor = kletka.soil.soilColor;
						break;
					}
				case 6:
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

		//Рассчёт вероятности спавна определенных деревьев
		private int plant_Placement(Cell kletka, int k, int l)
		{
			int kolvo = 401;
			
			int[] rand_mass = new int[kolvo];
			for (int i = 0; i < kolvo; i++)
				rand_mass[i] = 0;

			int[] plant_soil = new int[6]; //Массив для хранения требований разных растений

			Osina osina = new Osina();
			Klen klen = new Klen();
			El el = new El();

			plant_soil[0] = kletka.soil.prolificacy - osina.soil_demand;
			plant_soil[1] = kletka.soil.prolificacy - klen.soil_demand;
			plant_soil[2] = kletka.soil.prolificacy - el.soil_demand;

			int osina_chances = 2, klen_chances = 2, el_chances = 2;

			//Шансы деревьев прорасти при заданной плодородности
			if (Math.Abs(plant_soil[0]) <= 5)
				osina_chances += 0;
			else if (plant_soil[0] > 5 && plant_soil[0] <= 20)
				osina_chances += 1;
			else if (plant_soil[0] > 20 && plant_soil[0] <= 40)
				osina_chances += 2;
			else if (plant_soil[0] > 40)
				osina_chances += 3;
			else if (plant_soil[0] < -5 && plant_soil[0] >= -20)
				osina_chances -= 3;
			else if (plant_soil[0] < -20 && plant_soil[0] >= -40)
				osina_chances -= 4;
			else if (plant_soil[0] < -40)
				osina_chances -= 5;

			if (Math.Abs(plant_soil[1]) <= 5)
				klen_chances += 0;
			else if (plant_soil[1] > 5 && plant_soil[1] <= 20)
				klen_chances += 1;
			else if (plant_soil[1] > 20 && plant_soil[1] <= 40)
				klen_chances += 2;
			else if (plant_soil[1] > 40)
				klen_chances += 3;
			else if (plant_soil[1] < -5 && plant_soil[1] >= -20)
				klen_chances -= 3;
			else if (plant_soil[1] < -20 && plant_soil[1] >= -40)
				klen_chances -= 4;
			else if (plant_soil[1] < -40)
				klen_chances -= 5;

			if (Math.Abs(plant_soil[2]) <= 5)
				el_chances += 0;
			else if (plant_soil[2] > 5 && plant_soil[2] <= 20)
				el_chances += 1;
			else if (plant_soil[2] > 20 && plant_soil[2] <= 40)
				el_chances += 2;
			else if (plant_soil[2] > 40)
				el_chances += 3;
			else if (plant_soil[2] < -5 && plant_soil[2] >= -20)
				el_chances -= 3;
			else if (plant_soil[2] < -20 && plant_soil[2] >= -40)
				el_chances -= 4;
			else if (plant_soil[2] < -40)
				el_chances -= 5;

			//Шансы деревьев прорасти при заданной влажности почвы
			plant_soil[3] = kletka.soil.wetness - osina.water_demand;
			plant_soil[4] = kletka.soil.wetness - klen.water_demand;
			plant_soil[5] = kletka.soil.wetness - el.water_demand;

			if (Math.Abs(plant_soil[3]) <= 5)
				osina_chances += 3;
			else if (Math.Abs(plant_soil[3]) > 5 && Math.Abs(plant_soil[3]) <= 20)
				osina_chances += 4;
			else if (Math.Abs(plant_soil[3]) > 20 && Math.Abs(plant_soil[3]) <= 40)
				osina_chances -= 4;
			else if (Math.Abs(plant_soil[3]) > 40)
				osina_chances -= 5;


			if (Math.Abs(plant_soil[4]) <= 5)
				klen_chances += 3;
			else if (Math.Abs(plant_soil[4]) > 10 && Math.Abs(plant_soil[4]) <= 20)
				klen_chances += 4;
			else if (Math.Abs(plant_soil[4]) > 20 && Math.Abs(plant_soil[4]) <= 40)
				klen_chances -= 3;
			else if (Math.Abs(plant_soil[4]) > 40)
				klen_chances -= 4;


			if (Math.Abs(plant_soil[5]) <= 5)
				el_chances += 3;
			else if (Math.Abs(plant_soil[5]) > 10 && Math.Abs(plant_soil[5]) <= 20)
				el_chances += 4;
			else if (Math.Abs(plant_soil[5]) > 20 && Math.Abs(plant_soil[5]) <= 40)
				el_chances -= 4;
			else if (Math.Abs(plant_soil[5]) > 40)
				el_chances -= 5;


			if (kletka.soil.toxity <= 10)
			{
				el_chances -= 2;
				osina_chances -= 2;
			}
			else if (kletka.soil.toxity > 10 && kletka.soil.toxity <= 20)
			{
				el_chances -= 3;
				osina_chances -= 3;
			}
			else if (kletka.soil.toxity > 20 && kletka.soil.toxity <= 40)
			{
				el_chances -= 4;
				osina_chances -= 4;
			}
			else if (kletka.soil.toxity > 40)
			{
				el_chances -= 5;
				osina_chances -= 5;
			}


			if (kletka.plants.plantkind != PlantKind.Empty)
            {
				el_chances = 0;
				klen_chances = 0;
				osina_chances = 0;
			}
			
			if (isplantnear(kletka, k, l))
			{
				el_chances = el_chances / 3;
				klen_chances = klen_chances / 3;
				osina_chances = osina_chances / 3;
			}

			if (kletka.soil.soilkind == SoilKind.Pepel)
			{
				el_chances = 0;
				klen_chances = 0;
				osina_chances = 0;
			}

			if (osina_chances < 0)
				osina_chances = 0;
			if (klen_chances < 0)
				klen_chances = 0;
			if (el_chances < 0)
				el_chances = 0;


			//Добавление в массив вероятности 
			for (int i = 0; i < osina_chances; i++)
				rand_mass[i] = 1;

			for (int i = osina_chances; i < osina_chances + klen_chances; i++)
				rand_mass[i] = 2;

			for (int i = osina_chances + klen_chances; i < osina_chances + klen_chances + el_chances; i++)
				rand_mass[i] = 3;

			int random_pl = rand_mass[rand.Next(0, rand_mass.Length)];
			return random_pl;

		}

		private bool isplantnear(Cell kletka, int i, int j)
		{
			for (int k = i - 1; k < i + 2; k++)
				for (int l = j - 1; l < j + 2; l++)
				{
					if (buttons[k,l].plants.plantkind != PlantKind.Empty)
					{
						return true;
					}		
				}
			return false;
		}
		private void crown_Draw(Aircells[,] aircells, Cell kletka, int i, int j)
		{
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
						aircells[i, j].plants[aircells[i, j].plkolvo] = kletka.plants;
						aircells[i + 1, j].plants[aircells[i + 1, j].plkolvo] = kletka.plants;
						aircells[i + 2, j].plants[aircells[i + 2, j].plkolvo] = kletka.plants;
						aircells[i - 1, j].plants[aircells[i - 1, j].plkolvo] = kletka.plants;
						aircells[i - 2, j].plants[aircells[i - 2, j].plkolvo] = kletka.plants;					
						aircells[i, j - 1].plants[aircells[i, j - 1].plkolvo] = kletka.plants;
						aircells[i, j - 2].plants[aircells[i, j - 2].plkolvo] = kletka.plants;
						aircells[i, j + 1].plants[aircells[i, j + 1].plkolvo] = kletka.plants;					
						aircells[i, j + 2].plants[aircells[i, j + 2].plkolvo] = kletka.plants;					
						aircells[i + 1, j + 1].plants[aircells[i + 1, j + 1].plkolvo] = kletka.plants;
						aircells[i + 1, j - 1].plants[aircells[i + 1, j - 1].plkolvo] = kletka.plants;
						aircells[i - 1, j + 1].plants[aircells[i - 1, j + 1].plkolvo] = kletka.plants;
						aircells[i - 1, j - 1].plants[aircells[i - 1, j - 1].plkolvo] = kletka.plants;

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

						aircells[i, j].plkolvo++;
						aircells[i + 1, j].plkolvo++;
						aircells[i + 2, j].plkolvo++;
						aircells[i - 1, j].plkolvo++;
						aircells[i - 2, j].plkolvo++;
						aircells[i, j - 1].plkolvo++;
						aircells[i, j - 2].plkolvo++;
						aircells[i, j + 1].plkolvo++;
						aircells[i, j + 2].plkolvo++;
						aircells[i + 1, j + 1].plkolvo++;
						aircells[i + 1, j - 1].plkolvo++;
						aircells[i - 1, j + 1].plkolvo++;
						aircells[i - 1, j - 1].plkolvo++;

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
				kletka.plants.height += 0.9 * modif;
			}
			else if (kletka.plants.age > 3 && kletka.plants.age < 25 && kletka.plants.plantkind == PlantKind.Klen && kletka.plants.height < 25)
			{
				kletka.plants.height += 0.6 * modif;
			}

			if (kletka.plants.age <= 15 && kletka.plants.plantkind == PlantKind.El && kletka.plants.height < 35)
			{
				kletka.plants.height += 0.3 * modif;
			}
			else if (kletka.plants.age > 15 && kletka.plants.age < 60 && kletka.plants.plantkind == PlantKind.El && kletka.plants.height < 35)
			{
				kletka.plants.height += 0.5 * modif;
			}

			

		}

		private void age_check(Cell kletka)
		{
			if (kletka.plants.age > 120 && kletka.plants.plantkind == PlantKind.Osina)
			{
				kletka.plants.lifepoints -= 50;
			}

			if (kletka.plants.age > 100 && kletka.plants.plantkind == PlantKind.Klen)
			{
				kletka.plants.lifepoints -= 50;
			}

			if (kletka.plants.age > 300 && kletka.plants.plantkind == PlantKind.El)
			{
				kletka.plants.lifepoints -= 50;
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
			{
				kletka.plants.lifepoints += 2;
				modif += 0.3;
			}
			else if (plant_soil > 10 && plant_soil <= 30)
			{
				kletka.plants.lifepoints += 3;
				modif += 0.4;
			}
			else if (plant_soil > 30)
			{
				kletka.plants.lifepoints += 4;
				modif += 0.5;
			}
			else if (plant_soil < -10 && plant_soil >= -30)			
			{
				kletka.plants.lifepoints -= 5;
				modif -= 0.3;
			}			
			else if (plant_soil < -30 && plant_soil >= -60)
			{
				kletka.plants.lifepoints -= 7;
				modif -= 0.4;
			}			
			else if (plant_soil < -60)
			{
				kletka.plants.lifepoints -= 9;
				modif -= 0.5;
			}


			if (Math.Abs(plant_water) <= 10)
			{
				kletka.plants.lifepoints += 3;
				modif += 0.3;
			}
			else if (Math.Abs(plant_water) > 10 && Math.Abs(plant_water) <= 40)
			{
				kletka.plants.lifepoints += 4;
				modif += 0.4;
			}
			else if (Math.Abs(plant_water) > 40 && Math.Abs(plant_water) <= 100)
			{
				kletka.plants.lifepoints -= 7;
				modif -= 0.3;
			}
			else if (Math.Abs(plant_water) > 100)
			{
				kletka.plants.lifepoints -= 9;
				modif -= 0.4;
			}


			if (Math.Abs(plant_light) <= 10)
			{
				kletka.plants.lifepoints += 3;
				if (kletka.plants.plantkind == PlantKind.El)
					modif += 0.3;
				else
					modif += 0.4;
			}
			else if (Math.Abs(plant_light) > 10 && Math.Abs(plant_light) <= 30)
			{
				kletka.plants.lifepoints += 4;
				if (kletka.plants.plantkind == PlantKind.El)
					modif += 0.2;
				else
					modif += 0.3;
			}
			else if (Math.Abs(plant_light) > 30 && Math.Abs(plant_light) <= 60)
			{
				kletka.plants.lifepoints -= 7;
				if (kletka.plants.plantkind == PlantKind.El)
					modif -= 0.2;
				else
					modif -= 0.3;
			}
			else if (Math.Abs(plant_light) > 60)
			{
				kletka.plants.lifepoints -= 9;

				if (kletka.plants.plantkind == PlantKind.El)
					modif -= 0.3;
				else
					modif -= 0.4;
			}


			if (kletka.soil.toxity > 10 && kletka.plants.plantkind != PlantKind.Klen)
			{
				kletka.plants.lifepoints -= 2;
				modif -= 0.1;
			}
			else if (kletka.soil.toxity > 30 && kletka.plants.plantkind != PlantKind.Klen)
			{
				kletka.plants.lifepoints -= 4;
				modif -= 0.2;
			}
			else if (kletka.soil.toxity > 60 && kletka.plants.plantkind != PlantKind.Klen)
			{
				kletka.plants.lifepoints -= 6;
				modif -= 0.3;
			}
			else if (kletka.soil.toxity > 80 && kletka.plants.plantkind != PlantKind.Klen)
			{
				kletka.plants.lifepoints -= 8;
				modif -= 0.4;
			}


			if (kletka.plants.lifepoints > 50)
			{
				kletka.plants.lifepoints = 50;
			}
			
			if (modif < 0)
			{
				modif = 0;
			}
			return modif;
		}

		//Если дерево выше, на поле его крона будет отображаться поверх других при пересечении клеток
		public void crown_check()
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

		//Проверка смерти деревьев
		public void tree_dead()
        {
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (buttons[i, j].plants.plantkind != PlantKind.Empty && buttons[i, j].plants.lifepoints <= 0)
					{
						crown_Destroy();
						buttons[i, j].plants = new Empty();
						buttons[i, j].soil.prolificacy += 10;	//Сгнившее дерево превращается в удобрение					 
						buttons[i, j].BackColor = buttons[i, j].soil.soilColor;
						crown_refresh();
						crown_check();
					}

					if (buttons[i, j].fireflag)
					{
						crown_Destroy();
						buttons[i, j].plants = new Empty();
						buttons[i, j].soil = new Pepel();    //Почва становится пеплом				 
						buttons[i, j].BackColor = buttons[i, j].soil.soilColor;
						crown_refresh();
						crown_check();
					}
				}
			}		
		}

		//Уничтожение кроны умерших деревьев
		private void crown_Destroy()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					buttons2[i, j].BackColor = buttons[i, j].soil.soilColor;
					for (int k = 0; k < buttons2[i, j].plkolvo; k++)
					{
						buttons2[i, j].plants[k] = new Empty();
					}
					buttons2[i, j].plkolvo = 0;

				}
			}
		}

		//Обновление крон деревьев с учётом уничтоженных деревьев
		private void crown_refresh()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (buttons[i, j].plants.plantkind != PlantKind.Empty) 
						crown_Draw(buttons2, buttons[i, j], i, j);
				}
			}
		}

		private void plants_refresh()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					switch (buttons[i, j].plants.plantkind)
					{
						case PlantKind.Osina:
                        {
							if (buttons[i, j].plants.age > 0 && buttons[i, j].plants.height < 10)
							{
								buttons[i, j].plants.plantstage = PlantStage.Small;
							}
							if (buttons[i, j].plants.age > 15 && buttons[i, j].plants.height >= 15) 
							{
								buttons[i, j].plants.plantstage = PlantStage.Normal;
							}

							break;
                        }
						case PlantKind.Klen:
							{
								if (buttons[i, j].plants.age > 0 && buttons[i, j].plants.height < 10)
								{
									buttons[i, j].plants.plantstage = PlantStage.Small;
								}
								if (buttons[i, j].plants.age > 15 && buttons[i, j].plants.height >= 15)
								{
									buttons[i, j].plants.plantstage = PlantStage.Normal;
								}
								
								break;
							}
						case PlantKind.El:
							{
								if (buttons[i, j].plants.age > 0 && buttons[i, j].plants.height < 10)
								{
									buttons[i, j].plants.plantstage = PlantStage.Small;
								}
								if (buttons[i, j].plants.age > 15 && buttons[i, j].plants.height >= 15)
								{
									buttons[i, j].plants.plantstage = PlantStage.Normal;
								}

								break;
							}
						default:
						{							
							break;
						}
					}
					
				}
			}
		}
		private void soil_refresh()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if ((buttons[i, j].plants.plantkind == PlantKind.Empty && buttons[i, j].soil.soilkind != SoilKind.Pepel) || (buttons[i, j].plants.plantkind == PlantKind.Empty && buttons[i, j].soil.soilkind == SoilKind.Pepel && buttons[i, j].soil.wetness > 90))
					{
						if (buttons[i, j].soil.prolificacy <= 40)
						{
							buttons[i, j].soil.soilkind = SoilKind.Poor;
							buttons[i, j].BackColor = Color.FromArgb(208, 176, 132);
						}
						if (buttons[i, j].soil.prolificacy <= 70 && buttons[i, j].soil.prolificacy > 40)
						{
							buttons[i, j].soil.soilkind = SoilKind.Average;
							buttons[i, j].BackColor = Color.FromArgb(208, 156, 122);
						}
						if (buttons[i, j].soil.prolificacy <= 100 && buttons[i, j].soil.prolificacy > 70)
						{
							buttons[i, j].soil.soilkind = SoilKind.Rich;
							buttons[i, j].BackColor = Color.FromArgb(209, 137, 81);
						}
					}
                }
			}
		}

		private void air_refresh()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (buttons2[i, j].plkolvo == 0)
						buttons2[i, j].BackColor = buttons[i, j].soil.soilColor;
				
				}
			}
		}

		//Проверка освещенности клетки в зависимости от закрытия кроной деревьев
		private void lumine_check()
		{
			
			int lumbuf = Convert.ToInt32(window.luminetextBox.Text);
			
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (buttons2[i, j].plkolvo > 1 && buttons[i, j].plants.plantkind != PlantKind.Empty)
						buttons[i, j].illumination = lumbuf / isCrowntallest(buttons[i, j], buttons2[i, j]);
                    else if (buttons2[i, j].plkolvo >= 1 && buttons[i, j].plants.plantkind == PlantKind.Empty)
                    {
                        buttons[i, j].illumination = lumbuf / (buttons2[i, j].plkolvo + 1);
                    }
                    else buttons[i, j].illumination = lumbuf;
				}
			}
		}

		//Проверка самого высокого дерева (самое высокое дерево не будет закрыто кроной другого - это отразится на освещённости)
		public int isCrowntallest(Cell kletka, Aircells aircell)
		{
			Aircells airc_buf = new Aircells();			
			int maxindex = 1;

			for (int k = 0; k < aircell.plkolvo; k++)
			{
				for (int l = k + 1; l <= aircell.plkolvo; l++)
				{
					if (aircell.plants[k].height < aircell.plants[l].height)
					{
						airc_buf.plants[0] = aircell.plants[k];
						aircell.plants[k] = aircell.plants[l];
						aircell.plants[l] = airc_buf.plants[0];
					}
				}
			}
            for (int k = 0; k < aircell.plkolvo; k++)
            {
				if (kletka.plants == aircell.plants[k])
					maxindex = k + 1;
            }

			return maxindex;
        }


	}
}
