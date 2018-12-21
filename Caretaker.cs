using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    public class Caretaker
    {
        private Memento _memento;

        // Gets or sets memento
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
