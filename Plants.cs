using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ForestComp
{
    public enum PlantKind { Empty, El, Osina, Klen }
    public enum PlantStage { Small, Normal, Big }
    public class Plants
    {
        public PlantKind plantkind { get; set; }
        public PlantStage plantstage { get; set; } //Степень роста растения

        public Color trunkColor; //Цвет ствола
        public Color crownColor; //Цвет кроны
        public int lifepoints = 40; //Показатели жизни
        public int age = 0; //Возраст
        public double height = 0; //Высота
        public int grow_modific; //Модификатор роста
        public int soil_demand; //Требовательность к плодородности почвы
        public int water_demand; //Требовательность к воде
        public int light_demand; //Требовательность к свету

    }

    class Empty : Plants
    {
        public Empty()
        {
            this.plantkind = PlantKind.Empty;
            this.soil_demand = 0;
            this.water_demand = 0;
            this.light_demand = 0;
        }  
    }

    class Osina : Plants
    {
        public Osina()  //Осина - улучшает прододие почвы около себя, 
        {
            this.plantkind = PlantKind.Osina;
          
            this.crownColor = Color.FromArgb(120, 200, 0);
            //this.trunkColor = Color.FromArgb(220, 119, 0);
            this.trunkColor = Color.FromArgb(0, 240, 240);
            this.soil_demand = 50;
            this.water_demand = 60;
            this.light_demand = 70;
        }
    }

    class El : Plants
    {
        public El()
        {
            this.plantkind = PlantKind.El; 
            this.crownColor = Color.FromArgb(48, 80, 0);
            this.trunkColor = Color.FromArgb(128, 80, 208);
            //this.trunkColor = Color.FromArgb(248, 104, 48);
            this.soil_demand = 60;
            this.water_demand = 60;
            this.light_demand = 30;
        }
    }

    class Klen : Plants
    {
        public Klen()
        {
            this.plantkind = PlantKind.El;      
            this.crownColor = Color.FromArgb(80, 168, 120); 
            this.trunkColor = Color.FromArgb(248, 104, 48);
            this.soil_demand = 30;
            this.water_demand = 60;
            this.light_demand = 60;
        }
    }
}
