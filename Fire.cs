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
        public Color fireColor = Color.FromArgb(248, 120, 0);

        public Fire(Cell[,] cells, Aircells[,] aircells, Cell startkletka, int i, int j)
        {
            if (startkletka.soil.wetness < 120 && startkletka.plants.plantkind != PlantKind.Empty)
            {
                startkletka.BackColor = fireColor;
                if (cells[i, j] == startkletka)
                {
                    aircells[i, j].BackColor = fireColor;

                    go_right(cells, aircells, cells[i + 1, j], i + 1, j);
                    go_left(cells, aircells, cells[i - 1, j], i - 1, j);
                    go_up(cells, aircells, cells[i, j - 1], i, j - 1);
                    go_down(cells, aircells, cells[i, j + 1], i, j + 1);
                    //go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
                    //go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
                    //go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
                    //go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);

                }
            }

        }

        public void go_right(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        {
            if (cells[i, j] == kletka && cells[i, j].soil.wetness < 120 && kletka.plants.plantkind != PlantKind.Empty)
            {
                cells[i, j].BackColor = fireColor;
                aircells[i, j].BackColor = fireColor;

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
            if (cells[i, j] == kletka && cells[i, j].soil.wetness < 120 && kletka.plants.plantkind != PlantKind.Empty)
            {
                cells[i, j].BackColor = fireColor;
                aircells[i, j].BackColor = fireColor;
                go_left(cells, aircells, cells[i - 1, j], i - 1, j);
                go_up(cells, aircells, cells[i, j - 1], i, j - 1);
                go_down(cells, aircells, cells[i, j + 1], i, j + 1);
                //go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
                //go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
                //go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
                //go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
            }
        }
        public void go_up(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        {
            if (cells[i, j] == kletka && cells[i, j].soil.wetness < 120 && kletka.plants.plantkind != PlantKind.Empty)
            {
                cells[i, j].BackColor = fireColor;
                aircells[i, j].BackColor = fireColor;
                go_right(cells, aircells, cells[i + 1, j], i + 1, j);
                go_left(cells, aircells, cells[i - 1, j], i - 1, j);
                go_up(cells, aircells, cells[i, j - 1], i, j - 1);                
                //go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
                //go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
                //go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
                //go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
            }
        }
        public void go_down(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        {
            if (cells[i, j] == kletka && cells[i, j].soil.wetness < 120 && kletka.plants.plantkind != PlantKind.Empty)
            {
                cells[i, j].BackColor = fireColor;
                aircells[i, j].BackColor = fireColor;
                go_right(cells, aircells, cells[i + 1, j], i + 1, j);
                go_left(cells, aircells, cells[i - 1, j], i - 1, j);               
                go_down(cells, aircells, cells[i, j + 1], i, j + 1);
                //go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
                //go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
                //go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
                //go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
            }
        }

        //public void go_rightup(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        //{
        //    if (cells[i, j] == kletka && cells[i, j].soil.wetness < 120 && kletka.plants.plantkind != PlantKind.Empty)
        //    {
        //        cells[i, j].BackColor = fireColor;
        //        //go_right(cells, aircells, cells[i + 1, j], i + 1, j);
        //        //go_left(cells, aircells, cells[i - 1, j], i - 1, j);
        //        //go_up(cells, aircells, cells[i, j - 1], i, j - 1);
        //        //go_down(cells, aircells, cells[i, j + 1], i, j + 1);
        //        go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
        //        go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
        //        go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
        //    }
        //}

        //public void go_leftup(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        //{
        //    if (cells[i, j] == kletka && cells[i, j].soil.wetness < 120 && kletka.plants.plantkind != PlantKind.Empty)
        //    {
        //        cells[i, j].BackColor = fireColor;
        //        //go_right(cells, aircells, cells[i + 1, j], i + 1, j);
        //        //go_left(cells, aircells, cells[i - 1, j], i - 1, j);
        //        //go_up(cells, aircells, cells[i, j - 1], i, j - 1);
        //        //go_down(cells, aircells, cells[i, j + 1], i, j + 1);
        //        go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
        //        go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
        //        go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
        //    }
        //}
        //public void go_rightdown(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        //{
        //    if (cells[i, j] == kletka && cells[i, j].soil.wetness < 120 && kletka.plants.plantkind != PlantKind.Empty)
        //    {
        //        cells[i, j].BackColor = fireColor;
        //        //go_right(cells, aircells, cells[i + 1, j], i + 1, j);
        //        //go_left(cells, aircells, cells[i - 1, j], i - 1, j);
        //        //go_up(cells, aircells, cells[i, j - 1], i, j - 1);
        //        //go_down(cells, aircells, cells[i, j + 1], i, j + 1);
        //        go_rightup(cells, aircells, cells[i + 1, j - 1], i + 1, j - 1);
        //        go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
        //        go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
        //    }
        //}
        //public void go_leftdown(Cell[,] cells, Aircells[,] aircells, Cell kletka, int i, int j)
        //{
        //    if (cells[i, j] == kletka && cells[i, j].soil.wetness < 120 && kletka.plants.plantkind != PlantKind.Empty)
        //    {
        //        cells[i, j].BackColor = fireColor;
        //        //go_right(cells, aircells, cells[i + 1, j], i + 1, j);
        //        //go_left(cells, aircells, cells[i - 1, j], i - 1, j);
        //        //go_up(cells, aircells, cells[i, j - 1], i, j - 1);
        //        //go_down(cells, aircells, cells[i, j + 1], i, j + 1);
        //        go_leftup(cells, aircells, cells[i - 1, j - 1], i - 1, j - 1);
        //        go_rightdown(cells, aircells, cells[i + 1, j + 1], i + 1, j + 1);
        //        go_leftdown(cells, aircells, cells[i - 1, j + 1], i - 1, j + 1);
        //    }
        //}

    }
}
