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
    public partial class Window1 : Window, IBridge, IViewUpdator
    {
        public GameTimer timer { get; set; }
        public int BlockCount { get; set; } = 1;
        public Image block { get; set; }
        public TowerConroller tower { get; set; }
        public BlockContainer blockContainer { get; set; }
        public int lifes = 3;
        public IViewUpdator updater;
        BlockUi blockUi;
        public Window1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            tower = new TowerConroller();
            blockContainer = new BlockContainer();

            SpawnNewBlock();

            StartBlocksMovement();
            //BlockUi = new BlockUi();
        }

        public void BlockCollision()
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

        public void updateCanvas(double x)
        {
            Canvas.SetLeft(block, x);
        }

        public void StartBlocksMovement()
        {
            timer = new GameTimer(Settings.MOVE_TIMER);
        }

        public void StartBlockDrop()
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
            AddNewBlock(block);
        }


        public void DropBlock()
        {
            if (Canvas.GetTop(block) < 600 - tower.getLastBlockTop())
            {
                Canvas.SetTop(block, Canvas.GetTop(block) + Settings.moveStep);
            }
            else if (tower.isInRange(Canvas.GetLeft(block)))//blokelis uzsistackino
            {
                IBridge IBridge = this;
                AbstractBridge bridge = new AbstractBridge(IBridge);
                bridge.CallBlockCollision();
            }
            else if (Canvas.GetTop(block) < 700)//blokelis nukrito
            {
                Canvas.SetTop(block, Canvas.GetTop(block) + Settings.moveStep);
            }
            else
            {
                loseBlock();
            }
        }

        public void AddNewBlock(Image Block)
        {
            canvas.Children.Add(Block);
        }

        private void loseBlock()
        {
            lifes--;
            timer.StopTimer();
            SpawnNewBlock();
            StartBlocksMovement();
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



    }
}
