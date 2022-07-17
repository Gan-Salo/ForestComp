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

		public Board(MainForm win)
		{
			window = win;
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
						buttons[i, j].soil.wetness = buttons[i, j].soil.wetness - rand.Next(10, 25) + (buttons[i, j].illumination / 6);
					}
					
					check_all(buttons[i, j]);


					if (buttons[i, j].plants.plantkind != PlantKind.Empty)
					{
						tree_dead();    //Проверка жизни деревьев и уничтожение мертвых деревьев
						buttons[i, j].plants.age += 1;

						buttons[i, j].soil.wetness -= buttons[i, j].plants.water_demand / 5;    //Почва теряет количество воды, необходимое растению
						
						//Клён выделяет на клетки рядом с собой "токсичность"
						if (buttons[i, j].plants.plantkind == PlantKind.Klen)
						{
							buttons[i, j].soil.toxity += 2;
							buttons[i + 1, j].soil.toxity += 2;
							buttons[i - 1, j].soil.toxity += 2;
							buttons[i, j + 1].soil.toxity += 2;
							buttons[i, j - 1].soil.toxity += 2;							
						}
						
						plant_grow(buttons[i, j]);  //Отрисовка кроны в зависимости от стадии роста дерева	
						age_check(buttons[i, j]);	//Проверка возраста дерева		
					}
				}
			}

			soil_refresh();     //Обновление почвы		
			plants_refresh();
			crown_Destroy();
			crown_refresh();
			crown_check();	
			air_refresh();		
			lumine_check();		//Проверка зависимости освещённости клетки от крон деревьев
			
		}
		//Спавн деревьев
		public void plant_Choose(Cell kletka, int k, int l)
		{
			int random_plant = plant_Placement(kletka, k, l);

			switch (random_plant)
			{
				case 1:
					{
						kletka.plants = new Osina();
						kletka.plants.plantkind = PlantKind.Osina;
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

		//Изменения некорректных значений параметров
		public void check_all(Cell kletka)
		{
			if (kletka.soil.wetness < -50)
				kletka.soil.wetness = -50;

			if (kletka.soil.wetness > 120)
				kletka.soil.wetness = 120;

			if (kletka.illumination > 100)
				kletka.illumination = 100;

			if (kletka.illumination < 0)
				kletka.illumination = 0;

			if (kletka.soil.wetness > 100)
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
			
		//Размещение почвы на поле
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

		//Расчёт вероятности спавна определенных деревьев
		private int plant_Placement(Cell kletka, int k, int l)
		{
			int kolvo = 301;
			
			int[] rand_mass = new int[kolvo];
			for (int i = 0; i < kolvo; i++)
				rand_mass[i] = 0;

			int[] pl_demand = new int[9]; //Массив для хранения требований разных растений

			Osina osina = new Osina();
			Klen klen = new Klen();
			El el = new El();

			pl_demand[0] = kletka.soil.prolificacy - osina.soil_demand;
			pl_demand[1] = kletka.soil.prolificacy - klen.soil_demand;
			pl_demand[2] = kletka.soil.prolificacy - el.soil_demand;

			int osina_chances = 0, klen_chances = 1, el_chances = 0;

			//Шансы деревьев прорасти при заданной плодородности
			if (Math.Abs(pl_demand[0]) <= 5)
				osina_chances += 0;
			else if (pl_demand[0] > 5 && pl_demand[0] <= 20)
				osina_chances += 1;
			else if (pl_demand[0] > 20 && pl_demand[0] <= 40)
				osina_chances += 2;
			else if (pl_demand[0] > 40)
				osina_chances += 3;
			else if (pl_demand[0] < -5 && pl_demand[0] >= -20)
				osina_chances -= 3;
			else if (pl_demand[0] < -20 && pl_demand[0] >= -40)
				osina_chances -= 4;
			else if (pl_demand[0] < -40)
				osina_chances -= 5;

			if (Math.Abs(pl_demand[1]) <= 5)
				klen_chances += 0;
			else if (pl_demand[1] > 5 && pl_demand[1] <= 20)
				klen_chances += 1;
			else if (pl_demand[1] > 20 && pl_demand[1] <= 40)
				klen_chances += 2;
			else if (pl_demand[1] > 40)
				klen_chances += 3;
			else if (pl_demand[1] < -5 && pl_demand[1] >= -20)
				klen_chances -= 3;
			else if (pl_demand[1] < -20 && pl_demand[1] >= -40)
				klen_chances -= 4;
			else if (pl_demand[1] < -40)
				klen_chances -= 5;

			if (Math.Abs(pl_demand[2]) <= 5)
				el_chances += 0;
			else if (pl_demand[2] > 5 && pl_demand[2] <= 20)
				el_chances += 1;
			else if (pl_demand[2] > 20 && pl_demand[2] <= 40)
				el_chances += 2;
			else if (pl_demand[2] > 40)
				el_chances += 3;
			else if (pl_demand[2] < -5 && pl_demand[2] >= -20)
				el_chances -= 3;
			else if (pl_demand[2] < -20 && pl_demand[2] >= -40)
				el_chances -= 4;
			else if (pl_demand[2] < -40)
				el_chances -= 5;

			//Шансы деревьев прорасти при заданной влажности почвы
			pl_demand[3] = kletka.soil.wetness - osina.water_demand;
			pl_demand[4] = kletka.soil.wetness - klen.water_demand;
			pl_demand[5] = kletka.soil.wetness - el.water_demand;

			if (Math.Abs(pl_demand[3]) <= 5)
				osina_chances += 3;
			else if (Math.Abs(pl_demand[3]) > 5 && Math.Abs(pl_demand[3]) <= 20)
				osina_chances += 2;
			else if (Math.Abs(pl_demand[3]) > 20 && Math.Abs(pl_demand[3]) <= 40)
				osina_chances -= 3;
			else if (Math.Abs(pl_demand[3]) > 40)
				osina_chances -= 4;


			if (Math.Abs(pl_demand[4]) <= 5)
				klen_chances += 3;
			else if (Math.Abs(pl_demand[4]) > 10 && Math.Abs(pl_demand[4]) <= 20)
				klen_chances += 2;
			else if (Math.Abs(pl_demand[4]) > 20 && Math.Abs(pl_demand[4]) <= 40)
				klen_chances -= 3;
			else if (Math.Abs(pl_demand[4]) > 40)
				klen_chances -= 4;


			if (Math.Abs(pl_demand[5]) <= 5)
				el_chances += 3;
			else if (Math.Abs(pl_demand[5]) > 10 && Math.Abs(pl_demand[5]) <= 20)
				el_chances += 2;
			else if (Math.Abs(pl_demand[5]) > 20 && Math.Abs(pl_demand[5]) <= 40)
				el_chances -= 3;
			else if (Math.Abs(pl_demand[5]) > 40)
				el_chances -= 4;

			//Шансы деревьев прорасти при заданной освещённости
			pl_demand[6] = kletka.illumination - osina.light_demand;
			pl_demand[7] = kletka.illumination - klen.light_demand;
			pl_demand[8] = kletka.illumination - el.light_demand;

			if (Math.Abs(pl_demand[6]) <= 5)
				osina_chances += 3;
			else if (Math.Abs(pl_demand[6]) > 5 && Math.Abs(pl_demand[6]) <= 20)
				osina_chances += 2;
			else if (Math.Abs(pl_demand[6]) > 20 && Math.Abs(pl_demand[6]) <= 40)
				osina_chances -= 3;
			else if (Math.Abs(pl_demand[6]) > 40)
				osina_chances -= 4;


			if (Math.Abs(pl_demand[7]) <= 5)
				klen_chances += 3;
			else if (Math.Abs(pl_demand[7]) > 10 && Math.Abs(pl_demand[7]) <= 20)
				klen_chances += 2;
			else if (Math.Abs(pl_demand[7]) > 20 && Math.Abs(pl_demand[7]) <= 40)
				klen_chances -= 3;
			else if (Math.Abs(pl_demand[7]) > 40)
				klen_chances -= 4;


			if (Math.Abs(pl_demand[8]) <= 5)
				el_chances += 3;
			else if (Math.Abs(pl_demand[8]) > 10 && Math.Abs(pl_demand[8]) <= 20)
				el_chances += 2;
			else if (Math.Abs(pl_demand[8]) > 20 && Math.Abs(pl_demand[8]) <= 40)
				el_chances -= 3;
			else if (Math.Abs(pl_demand[8]) > 40)
				el_chances -= 4;


			if (kletka.soil.toxity <= 10)
			{
				el_chances -= 2;
				osina_chances -= 2;
			}
			else if (kletka.soil.toxity > 10 && kletka.soil.toxity <= 30)
			{
				el_chances -= 3;
				osina_chances -= 3;
			}
			else if (kletka.soil.toxity > 30 && kletka.soil.toxity <= 60)
			{
				el_chances -= 4;
				osina_chances -= 4;
			}
			else if (kletka.soil.toxity > 60)
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

		//Проверка наличия рядом с клеткой растущего дерева
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

		//Отрисовка кроны дерева
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

		//Проверка возраста деревьев и умерщвление слишком старых
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

		//Учёт условий, влияющих на рост дерева
		private double growth_modificator(Cell kletka)
		{
			double modif = 0;
			int pl_demand = kletka.soil.prolificacy - kletka.plants.soil_demand;
			int plant_water = kletka.soil.wetness - kletka.plants.water_demand;
			int plant_light = kletka.illumination - kletka.plants.light_demand;
			
			//Шансы деревьев прорасти при заданной плодородности
			if (Math.Abs(pl_demand) <= 10)
			{
				kletka.plants.lifepoints += 2;
				modif += 0.3;
			}
			else if (pl_demand > 10 && pl_demand <= 30)
			{
				kletka.plants.lifepoints += 3;
				modif += 0.4;
			}
			else if (pl_demand > 30)
			{
				kletka.plants.lifepoints += 4;
				modif += 0.5;
			}
			else if (pl_demand < -10 && pl_demand >= -30)			
			{
				kletka.plants.lifepoints -= 5;
				modif -= 0.3;
			}			
			else if (pl_demand < -30 && pl_demand >= -60)
			{
				kletka.plants.lifepoints -= 7;
				modif -= 0.4;
			}			
			else if (pl_demand < -60)
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


			if (kletka.soil.toxity <= 40 && kletka.plants.plantkind != PlantKind.Klen)
			{
				kletka.plants.lifepoints -= 1;
				modif -= 0.1;
			}
			else if (kletka.soil.toxity > 40 && kletka.soil.toxity <= 60 && kletka.plants.plantkind != PlantKind.Klen)
			{
				kletka.plants.lifepoints -= 2;
				modif -= 0.2;
			}
			else if (kletka.soil.toxity > 60 && kletka.soil.toxity <= 80 && kletka.plants.plantkind != PlantKind.Klen)
			{
				kletka.plants.lifepoints -= 3;
				modif -= 0.3;
			}
			else if (kletka.soil.toxity > 80 && kletka.plants.plantkind != PlantKind.Klen)
			{
				kletka.plants.lifepoints -= 4;
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

		//Проверка смерти деревьев и уничтожение их кроны
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

		//Обновление стадий роста растений
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
							if (buttons[i, j].plants.age > 0 && buttons[i, j].plants.height < 15)
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
								if (buttons[i, j].plants.age > 0 && buttons[i, j].plants.height < 15)
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
								if (buttons[i, j].plants.age > 0 && buttons[i, j].plants.height < 15)
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

		//Обновление почвы
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

		//Обновление клеток второго поля
		private void air_refresh()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (buttons2[i, j].plkolvo == 0)
						buttons2[i, j].BackColor = buttons[i, j].BackColor;
				
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
					{
						buttons[i, j].illumination = lumbuf / isCrowntallest(buttons[i, j], buttons2[i, j]);
					}
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
