using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ForestComp
{
    public class Fire : Cell
    {
        AirFire airFire;
        public Color fireColor = Color.FromArgb(248, 120, 0);

        public Fire(Cell[,] cells, Aircells[,] aircells, Cell startkletka, int i, int j)
        {         
            if (!cells[i, j].fireflag /*&& startkletka.soil.wetness < 120*/ && startkletka.plants.plantkind != PlantKind.Empty)
            {
                startkletka.BackColor = fireColor;
                if (cells[i, j] == startkletka)
                {
                    aircells[i, j].BackColor = fireColor;
                    cells[i, j].fireflag = true;
                    
                    if (!aircells[i, j].fireflag) 
                        airFire = new AirFire(cells, aircells, aircells[i, j], i, j);
                    
                    go_right(cells, aircells, cells[i + 1, j], i + 1, j);
                    go_left(cells, aircells, cells[i - 1, j], i - 1, j);
                    go_up(cells, aircells, cells[i, j - 1], i, j - 1);
                    go_down(cells, aircells, cells[i, j + 1], i, j + 1);
                   
                }
            }
        }

        public void go_right(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        {
            if (!cells[i, j].fireflag && cells[i, j] == kletka /*&& cells[i, j].soil.wetness < 120*/ && kletka.plants.plantkind != PlantKind.Empty)
            {
                cells[i, j].BackColor = fireColor;
                
                if (!aircells[i, j].fireflag)
                    airFire = new AirFire(cells, aircells, aircells[i, j], i, j);

                cells[i, j].fireflag = true;

                go_right(cells, aircells, cells[i + 1, j], i + 1, j);               
                go_up(cells, aircells, cells[i, j - 1], i, j - 1);
                go_down(cells, aircells, cells[i, j + 1], i, j + 1);
                
                //go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
                //go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
                //go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
                //go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
            }
        }

        public void go_left(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        {
            if (!cells[i, j].fireflag && cells[i, j] == kletka /*&& cells[i, j].soil.wetness < 120*/ && kletka.plants.plantkind != PlantKind.Empty)
            {
                if (!aircells[i, j].fireflag)
                    airFire = new AirFire(cells, aircells, aircells[i, j], i, j);

                cells[i, j].BackColor = fireColor;
                //aircells[i, j].BackColor = fireColor;
                go_left(cells, aircells, cells[i - 1, j], i - 1, j);
                go_up(cells, aircells, cells[i, j - 1], i, j - 1);
                go_down(cells, aircells, cells[i, j + 1], i, j + 1);
                cells[i, j].fireflag = true;
                //go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
                //go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
                //go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
                //go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
            }
        }
        public void go_up(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        {
            if (!cells[i, j].fireflag && cells[i, j] == kletka /*&& cells[i, j].soil.wetness < 120*/ && kletka.plants.plantkind != PlantKind.Empty)
            {
                if (!aircells[i, j].fireflag)
                    airFire = new AirFire(cells, aircells, aircells[i, j], i, j);

                cells[i, j].BackColor = fireColor;
                //aircells[i, j].BackColor = fireColor;
                go_right(cells, aircells, cells[i + 1, j], i + 1, j);
                go_left(cells, aircells, cells[i - 1, j], i - 1, j);
                go_up(cells, aircells, cells[i, j - 1], i, j - 1);
                cells[i, j].fireflag = true;
                //go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
                //go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
                //go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
                //go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
            }
        }
        public void go_down(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        {
            if (!cells[i, j].fireflag && cells[i, j] == kletka /*&& cells[i, j].soil.wetness < 120*/ && kletka.plants.plantkind != PlantKind.Empty)
            {
                if (!aircells[i, j].fireflag)
                    airFire = new AirFire(cells, aircells, aircells[i, j], i, j);

                cells[i, j].BackColor = fireColor;
                //aircells[i, j].BackColor = fireColor;
                go_right(cells, aircells, cells[i + 1, j], i + 1, j);
                go_left(cells, aircells, cells[i - 1, j], i - 1, j);               
                go_down(cells, aircells, cells[i, j + 1], i, j + 1);
                cells[i, j].fireflag = true;
                //go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
                //go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
                //go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
                //go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
            }
        }


    }
}
