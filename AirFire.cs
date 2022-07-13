using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ForestComp
{
    public class AirFire : Cell
    {
        public Color airfireColor = Color.FromArgb(248, 120, 0);
        public AirFire(Cell[,] cells, Aircells[,] aircells, Aircells startkletka, int i, int j)
        {
            
            if (startkletka.plkolvo != 0)
            {
                //startkletka.BackColor = airfireColor;
                if (!aircells[i, j].fireflag && aircells[i, j] == startkletka)
                {                
                    if (!cells[i, j].fireflag && cells[i, j].plants.plantkind != PlantKind.Empty)
                    {
                        cells[i, j].BackColor = airfireColor;
                        cells[i, j].fireflag = true;
                    }
                    aircells[i, j].BackColor = airfireColor;
                    aircells[i, j].fireflag = true; 
                    go_right(cells, aircells, aircells[i + 1, j], i + 1, j);
                    go_left(cells, aircells, aircells[i - 1, j], i - 1, j);
                    go_up(cells, aircells, aircells[i, j - 1], i, j - 1);
                    go_down(cells, aircells, aircells[i, j + 1], i, j + 1);
                }
            }
        }

        public void go_right(Cell[,] cells, Aircells[,] aircells, Aircells kletka, int i, int j)
        {
            if (!aircells[i, j].fireflag && kletka.plkolvo != 0)
            {
                if (!cells[i, j].fireflag && cells[i, j].plants.plantkind != PlantKind.Empty)
                {
                    cells[i, j].BackColor = airfireColor;
                    cells[i, j].fireflag = true;
                }
                aircells[i, j].BackColor = airfireColor;
                aircells[i, j].fireflag = true;
                go_right(cells, aircells, aircells[i + 1, j], i + 1, j);
                go_up(cells, aircells, aircells[i, j - 1], i, j - 1);
                go_down(cells, aircells, aircells[i, j + 1], i, j + 1);
            }
        }

        public void go_left(Cell[,] cells, Aircells[,] aircells, Aircells kletka, int i, int j)
        {
            if (!aircells[i, j].fireflag && kletka.plkolvo != 0)
            {
                if (!cells[i, j].fireflag && cells[i, j].plants.plantkind != PlantKind.Empty)
                {
                    cells[i, j].BackColor = airfireColor;
                    cells[i, j].fireflag = true;
                }
                aircells[i, j].BackColor = airfireColor; 
                aircells[i, j].fireflag = true;
                go_left(cells, aircells, aircells[i - 1, j], i - 1, j);
                go_up(cells, aircells, aircells[i, j - 1], i, j - 1);
                go_down(cells, aircells, aircells[i, j + 1], i, j + 1);            
            }
        }
        public void go_up(Cell[,] cells, Aircells[,] aircells, Aircells kletka, int i, int j)
        {
            if (!aircells[i, j].fireflag && kletka.plkolvo != 0)
            {
                if (!cells[i, j].fireflag && cells[i, j].plants.plantkind != PlantKind.Empty)
                { 
                    cells[i, j].BackColor = airfireColor;
                    cells[i, j].fireflag = true;
                }

                aircells[i, j].BackColor = airfireColor; 
                aircells[i, j].fireflag = true;
                go_right(cells, aircells, aircells[i + 1, j], i + 1, j);
                go_left(cells, aircells, aircells[i - 1, j], i - 1, j);
                go_up(cells, aircells, aircells[i, j - 1], i, j - 1);             
            }
        }
        public void go_down(Cell[,] cells, Aircells[,] aircells, Aircells kletka, int i, int j)
        {
            if (!aircells[i, j].fireflag && kletka.plkolvo != 0)
            {
                if (!cells[i, j].fireflag && cells[i, j].plants.plantkind != PlantKind.Empty)
                {
                    cells[i, j].BackColor = airfireColor;
                    cells[i, j].fireflag = true;
                }
                aircells[i, j].BackColor = airfireColor; 
                aircells[i, j].fireflag = true;
                go_right(cells, aircells, aircells[i + 1, j], i + 1, j);
                go_left(cells, aircells, aircells[i - 1, j], i - 1, j);
                go_down(cells, aircells, aircells[i, j + 1], i, j + 1);
   
            }
        }
    }
}
