using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class MoveFasterSpeed : IStrategy
    {
        public void changeSpeed()
        {
            Settings.moveSpeed = 10;
        }
    }
}
