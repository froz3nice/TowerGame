using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TowerGame
{
    public class StateFalling : IState
    {
        public void Handle(Block b)
        {
            Console.WriteLine("Falling");
            b.timer.StopTimer();
            b.timer = new GameTimer(Settings.DROP_TIMER, b);
            b.isMoving = false;
            b.State = new StateMoving();
        }
    }
}
