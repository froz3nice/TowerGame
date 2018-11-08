using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class MoveVeryFastSpeed : IStrategy
    {
        public void changeSpeed()
        {
            Settings.moveSpeed = 1;
            Settings.moveStep = 7;
        }
    }
}
