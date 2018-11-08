using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    interface IMovement
    {
        void StraightMovement();
        void DownMovement();
        void StopStraightMovement();
        void StopDownMovement();
    }
}
