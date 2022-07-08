using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestComp
{
    //Почва
    public enum SoilKind { None,  }
    public enum SoilSprite { None, }  //Массив доступных для почвы цветов
    public class Soil
    {
        public SoilKind soilkind { get; set; }
        public SoilSprite soilsprite { get; set; }
        public int prolificacy; //Плодородность
        public int parasites;   //Насекомые и паразиты (уменьшают плодородность)
        public int wetness;     //Влажность 
        
    }
    class None : Soil
    {
        public None()
        {
            //this.
        }
    }
}
