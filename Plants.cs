using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ForestComp
{
    public enum PlantKind { Empty, Osina, Sosna }
    public class Plants
    {
        public PlantKind plantkind { get; set; }
        public Color trunkColor; //Цвет ствола
        public Color crownColor; //Цвет кроны
        public int age; //Возраст
        public int height; //Высота
        public int soil_demand; //Требовательность к плодородности почвы
        public int water_demand; //Требовательность к воде
        public int light_demand; //Требовательность к свету

    }

    class Empty : Plants
    {
        public Empty()
        {
            this.plantkind = PlantKind.Empty;
        }
    }

    class Osina : Plants
    {
        public Osina()
        {
            this.plantkind = PlantKind.Osina;
        }
    }

    class Sosna : Plants
    {
        public Sosna()
        {
            this.plantkind = PlantKind.Sosna;
        }
    }

}
