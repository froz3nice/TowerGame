using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TowerGame
{
    public class StateMoving : IState
    {
        public void Handle(Block b)
        {
            Console.WriteLine("moving");
            if(b.timer!=null)
            b.timer.StopTimer();
            b.timer = new GameTimer(Settings.MOVE_TIMER, b);
            b.isMoving = true;
            b.State = new StateFalling();
        }
    }
}
