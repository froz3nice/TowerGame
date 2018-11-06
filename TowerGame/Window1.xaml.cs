using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TowerGame
{
    public partial class Window1 : Window, IViewUpdator
    {
        GameTimer timer;
        int BlockCount = 1;
        Image block;
        TowerConroller tower;
        private BlockContainer blockContainer;
        int lifes = 3;
        public Window1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            tower = new TowerConroller();
            blockContainer = new BlockContainer();
            SpawnNewBlock();
            
            StartBlocksMovement();

        }

        private void StartBlocksMovement()
        {
            timer = new GameTimer(Settings.MOVE_TIMER);
        }

        private void StartBlockDrop()
        {
            timer = new GameTimer(Settings.DROP_TIMER);
        }

        private void SpawnNewBlock()
        {
            block = new Image();
            block.Source = new BitmapImage(new Uri(@"\block.png", UriKind.Relative));
            BlockCount++;
            block.Name = "Block" + BlockCount.ToString();
            block.Height = Settings.BlockHeight;
            block.Width = Settings.BlockWidth;
            Canvas.SetLeft(block, 30);
            Canvas.SetTop(block, 0);
            canvas.Children.Add(block);
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    timer.StopTimer();
                    StartBlockDrop();
                    break;
            }

        }

        private void GameOver()
        {
            // MessageBox.Show($@"You Lose! Your score is { _score}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Hand);
            this.Close();
        }

        public void updateCanvas(double x)
        {
            Canvas.SetLeft(block, x);
        }

        public void DropBlock()
        {
            if (Canvas.GetTop(block) < 600 - tower.getLastBlockTop())
            {
                Canvas.SetTop(block, Canvas.GetTop(block) + Settings.moveStep);
            }
            else if (tower.isInRange(Canvas.GetLeft(block)))//blokelis uzsistackino
            {
                stackBlock();
            }
            else if(Canvas.GetTop(block) < 700)//blokelis nukrito
            {
                Canvas.SetTop(block, Canvas.GetTop(block) + Settings.moveStep);
            }
            else
            {
                loseBlock();
            }
        }

        private void loseBlock()
        {
            lifes--;
            timer.StopTimer();
            SpawnNewBlock();
            StartBlocksMovement();
        }

        private void stackBlock()
        {
            blockContainer.AddBlock(block);
            tower.addHeight(Settings.BlockHeight);
            tower.SetTargetRange(Canvas.GetLeft(block), Canvas.GetRight(block));
            timer.StopTimer();
            SpawnNewBlock();
            StartBlocksMovement();
            Thread.Sleep(100);
            MoveBlocksDown();
        }

        private void MoveBlocksDown()
        {
            if (tower.areBlocksReadyToMoveDown())
            {
                foreach (Image img in blockContainer.getBlocks())
                {
                    Canvas.SetTop(img, Canvas.GetTop(img) + Settings.BlockHeight);
                }
            }
        }
    }
}
