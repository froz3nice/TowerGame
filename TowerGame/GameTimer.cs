using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    public class GameTimer
    {
        Block block;
        Block enemyBlock;

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer enemyTimer = new System.Windows.Threading.DispatcherTimer();

        public GameTimer(String whichTimer)
        {
            block = new Block();
            if (whichTimer.Equals(Settings.MOVE_TIMER))
            {
                timer.Tick += block.MoveBlock;
                timer.Interval = new TimeSpan(0, 0, 0, 0, Settings.moveSpeed);
                timer.Start();
            } 

            else if(whichTimer.Equals(Settings.DROP_TIMER))
            {
                timer.Tick += block.DropBlock;
                timer.Interval = new TimeSpan(0, 0, 0, 0, Settings.dropSpeed);
                timer.Start();
            }

            enemyBlock = new Block();
            if (whichTimer.Equals(Settings.MOVE_TIMER))
            {
                enemyTimer.Tick += enemyBlock.MoveEnemyBlock;
                enemyTimer.Interval = new TimeSpan(0, 0, 0, 0, Settings.moveSpeedEnemy);
                enemyTimer.Start();
            }

            else if (whichTimer.Equals(Settings.DROP_TIMER))
            {
               // enemyTimer.Tick += enemyBlock.DropBlock;
                //enemyTimer.Interval = new TimeSpan(0, 0, 0, 0, Settings.dropSpeed);
               // enemyTimer.Start();
            }
        }

        internal void StopTimer()
        {
            timer.Stop();
        }
    }
}
