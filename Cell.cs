using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ForestComp
{
    public partial class Cell : Button
    {
        public Location location = new Location();
        public Soil soil = new None();      //Почва
        public Plants plants = new Empty();     //Растения
        public int illumination;    //Степень освещённости клетки

        private void Kletka_Load(object sender, EventArgs e)
        {           
            this.Width = 15;
            this.Height = 15;
        }
        /*Получения Y координаты клетки*/
        public int GetY
        {
            get
            {
                return location.y;
            }
        }
        /*Получения X координаты клетки*/
        public int GetX
        {
            get
            {
                return location.x;
            }
        }
        public Cell()
        {
            this.Width = 15;
            this.Height = 15;

        }
        /*Конструктор для расположения клетки в пространстве*/
        public Cell(int y, int x)
        {
            location.y = y;
            location.x = x;
            Location = new Point(x * Size.Width, y * Size.Height);
        }

       

    }
    
    /*Координаты клетки на доске*/
    public struct Location
    {
        public int y, x;
    }
}
