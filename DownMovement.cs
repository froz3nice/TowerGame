using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class DownMovement
    {
        Block block;

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public DownMovement()
        {

        }

        public void Start()
        {
            block = new Block();

            timer.Tick += block.DropBlock;
            timer.Interval = new TimeSpan(0, 0, 0, 0, Settings.dropSpeed);
            timer.Start();
        }

        internal void StopTimer()
        {
            timer.Stop();
        }
    }
}
