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

        private static int X_coordEnemy = 46;
        private static int Y_coordEnemy = 0;
        bool checker = false;
        bool Enemychecker = false;
        public bool isMoving = false;
        public GameTimer timer;
       
         IViewUpdator view;
        private IState state;

        private IStrategy speed;

        public void setStrategy(IStrategy s)
        {
            //this.speed = s;
        }

        public void changeMovementSpeed()
        {
           // speed.changeSpeed();
        }

        public Block()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Window1))
                {
                    view = ((Window1)window);
                }
            }
            state = new StateMoving();
            //Request();
        }

        public void MoveEnemyBlock(object sender, EventArgs e)
        {
            
            if (Enemychecker == false)
            {
                X_coordEnemy += Settings.moveStepEnemy;
                if (X_coordEnemy >= Settings.max_x_to_right)
                {
                    Enemychecker = true;
                }
            }
            else if (Enemychecker == true)
            {
                X_coordEnemy -= Settings.moveStepEnemy;
                if (X_coordEnemy <= Settings.max_x_to_left)
                {
                    Enemychecker = false;
                }
            }
            view.updateEnemyCanvas((double)X_coordEnemy);
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

        public void DropEnemyBlock(object sender, EventArgs e)
        {
            view.DropEnemyBlock();
        }

        public void GoNext()
        {
            state.Handle(this);
        }
        public IState State
        {
            get { return state; }
            set { state = value; }
        }

    }
}
