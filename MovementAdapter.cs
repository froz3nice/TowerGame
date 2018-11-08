using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class MovementAdapter : IMovement
    {
        StraightMovement sm = new StraightMovement();
        DownMovement dm = new DownMovement();

        public void StraightMovement()
        {
            sm.Start();
        }

        public void StopStraightMovement()
        {
            sm.StopTimer();
        }

        public void DownMovement()
        {
            dm.Start();
        }

        public void StopDownMovement()
        {
            dm.StopTimer();
        }
    }
}
