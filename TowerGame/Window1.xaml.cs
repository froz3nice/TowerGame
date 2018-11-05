using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TowerGame
{
    public partial class Window1 : Window
    {
        //private enum GameSpeed
        //{
        //    Fast = 1,
        //    Moderate = 10000,
        //    Slow = 50000,
        //    DamnSlow = 500000
        //};

        bool checker = false;

        private int X_coord = 46;
        private int Y_coord = 0;
        private int moveStep = 5;
        private int max_x_to_right = 300;
        private int max_x_to_left = 46;
        private int moveSpeed = 20;
        private int dropSpeed = 10;
        System.Windows.Threading.DispatcherTimer blockMovementTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer blockDropTimer = new System.Windows.Threading.DispatcherTimer();

        public Window1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);

            StartBlocksMovement();
        }

        private void StartBlocksMovement()
        {
            blockMovementTimer.Tick += MoveBlock;
            blockMovementTimer.Interval = new TimeSpan(0, 0, 0, 0, moveSpeed);
            blockMovementTimer.Start();
        }

        private void StartBlockDrop()
        {
            blockDropTimer.Tick += DropBlock;
            blockDropTimer.Interval = new TimeSpan(0, 0, 0, 0, dropSpeed);
            blockDropTimer.Start();
        }

        private void MoveBlock(object sender, EventArgs e)
        {
            if(checker == false)
            {
                X_coord += moveStep;
                if(X_coord >= max_x_to_right)
                {
                    checker = true;
                }
            }
            else if(checker == true)
            {
                X_coord -= moveStep;
                if(X_coord <= max_x_to_left)
                {
                    checker = false;
                }
            }

            Canvas.SetLeft(Block1, (double)X_coord);
        }

        private void DropBlock(object sender, EventArgs e)
        {
            if(Canvas.GetTop(Block1) < 520)
                Canvas.SetTop(Block1, Canvas.GetTop(Block1) + moveStep);
            else
                blockDropTimer.Stop();
        }

    

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    blockMovementTimer.Stop();
                    StartBlockDrop();
                    break;
            }

        }

        private void GameOver()
        {
           // MessageBox.Show($@"You Lose! Your score is { _score}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Hand);
            this.Close();
        }

      
    }
}
