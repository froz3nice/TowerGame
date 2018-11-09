using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class StraightMovement
    {
        Block block;

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public StraightMovement()
        {

        }

        public void Start()
        {
            block = new Block();

            timer.Tick += block.MoveBlock;
            timer.Interval = new TimeSpan(0, 0, 0, 0, Settings.moveSpeed);
            timer.Start();
        }

        internal void StopTimer()
        {
            timer.Stop();
        }
    }
}
