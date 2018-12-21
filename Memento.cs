using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TowerGame
{
    public class Memento
    {
        private List<Image> blockss = new List<Image>();

        //Constructor
        public Memento(List<Image> blocks)
        {
            foreach (Image i in blocks)
                this.blockss.Add(i);
        }

        //Gets or sets state
        public List<Image> block
        {
            get { return this.blockss; }
        }
    }


}
