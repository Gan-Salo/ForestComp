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
    public class Aircells : Button
    {
        public int plkolvo = 0;
        public Plants[] plants = { new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty() }; 

         public Aircells()
        {
            
            this.Width = 15;
            this.Height = 15;
        }
        
    }
   
}

