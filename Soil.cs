﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ForestComp
{
    //Почва
    public enum SoilKind { None, Poor, Average, Rich }
   
    public class Soil
    {
        public SoilKind soilkind { get; set; }
        public Color soilColor;
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

    class Poor : Soil
    {
        public Poor()
        {
            this.soilkind = SoilKind.Poor;
            this.prolificacy = 20;
            this.soilColor = Color.FromArgb(208, 176, 132);
        }
    }

    class Average : Soil
    {
        public Average()
        {
            this.soilkind = SoilKind.Average;
            this.prolificacy = 50;
            this.soilColor = Color.FromArgb(209, 147, 71);
        }
    }

    class Rich : Soil
    {
        public Rich()
        {
            this.soilkind = SoilKind.Rich;
            this.soilColor = Color.FromArgb(162, 130, 98);
            this.prolificacy = 80;
        }
    }

}
