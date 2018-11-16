using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TowerGame
{
    public class Block
    {
        private static int X_coord = 46;
        private static int Y_coord = 0;
        bool checker = false;
        IViewUpdator view;

        private IStrategy speed;

        public void setStrategy(IStrategy s)
        {
            this.speed = s;
        }

        public void changeMovementSpeed()
        {
            speed.changeSpeed();
        }

        public Block()
        {
            //foreach (Window window in Application.Current.Windows)
            //{
            //    if (window.GetType() == typeof(Window1))
            //    {
            //        view = ((Window1)window);
            //    }
            //}
        }

        public void MoveBlock(object sender, EventArgs e)
        {
            if (checker == false)
            {
                X_coord += Settings.moveStep;
                if (X_coord >= Settings.max_x_to_right)
                {
                    checker = true;
                }
            }
            else if (checker == true)
            {
                X_coord -= Settings.moveStep;
                if (X_coord <= Settings.max_x_to_left)
                {
                    checker = false;
                }
            }
            view.updateCanvas((double)X_coord);
        }

        public void DropBlock(object sender, EventArgs e)
        {
            view.DropBlock();
        }

    }
}
