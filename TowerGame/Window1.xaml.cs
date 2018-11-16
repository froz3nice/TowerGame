using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TowerGame
{
    public partial class Window1 : Window, IBridge, IViewUpdator
    {
        public GameTimer timer { get; set; }
        public int BlockCount { get; set; } = 0;
        public TowerConroller tower { get; set; }
        public BlockContainer blockContainer { get; set; }
        public int lifes = 3;
        public IViewUpdator updater;
        public ICommand c;
        BlockUi blockUi;
        Block b = new Block();
        BlockFactory blockFactory = new BlockFactory();
        int points = 0;

        public Window1()
        {
            InitializeComponent();
            KeyEvent ke = new KeyEvent(this);
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            tower = new TowerConroller();
            blockContainer = new BlockContainer();

            SpawnNewBlock();

            StartBlocksMovement();
            //BlockUi = new BlockUi();
        }

        public void BlockCollision()
        {
            blockContainer.AddBlock(Settings.block);
            tower.addHeight(Settings.BlockHeight);
            tower.SetTargetRange(Canvas.GetLeft(Settings.block), Canvas.GetRight(Settings.block));
            timer.StopTimer();
            SpawnNewBlock();
            StartBlocksMovement();
            Thread.Sleep(100);
            MoveBlocksDown();
        }

        public void updateCanvas(double x)
        {
            Canvas.SetLeft(Settings.block, x);
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
            
            Settings.block = new Image();
            changeSkin(BlockCount);
            BlockCount++;
            ChangeBlockSpeed(BlockCount);
            Settings.block.Name = "Block" + BlockCount.ToString();
            Settings.block.Height = Settings.BlockHeight;
            Settings.block.Width = Settings.BlockWidth;
            Settings.block.Stretch = Stretch.Fill;
            Canvas.SetLeft(Settings.block, 30);
            Canvas.SetTop(Settings.block, 0);
            AddNewBlock(Settings.block);
        }



        /// <summary>
        /// Decorator pattern.
        /// </summary>
        /// <param name="blockCount"></param>
        public int changeSkin(int blockCount)
        {
            if (blockCount == 0)
            {
                Skin normalPoints = new NormalPointsDecorator(new DefaultSkin());
                normalPoints.draw();
            }
            else if (tower.getPerfectDrop())
            {
                Settings.BlockWidth = blockFactory.getBlock("SQUARE");
                Settings.block.Stretch = Stretch.Fill;
                Skin doublePoints = new DoublePointsDecorator(new DoublePointsSkin());
                doublePoints.draw();
            }
            else
            {
                Settings.BlockWidth = blockFactory.getBlock("RECTANGLE");
                Settings.block.Stretch = Stretch.Fill;
                Skin normalPoints = new NormalPointsDecorator(new DefaultSkin());
                normalPoints.draw();
            }
            return Settings.points;
        }

        /// <summary>
        /// Decorator pattern.
        /// </summary>
        /// <param name="blockCount"></param>
        public int changeSkin_forTest(int blockCount, TowerConroller t)
        {
            if (blockCount == 0)
            {
                Skin normalPoints = new NormalPointsDecorator(new DefaultSkin());
                normalPoints.draw();
            }
            else if (t.getPerfectDrop())
            {
                Settings.BlockWidth = blockFactory.getBlock("SQUARE");
                Settings.block.Stretch = Stretch.Fill;
                Skin doublePoints = new DoublePointsDecorator(new DoublePointsSkin());
                doublePoints.draw();
            }
            else
            {
                Settings.BlockWidth = blockFactory.getBlock("RECTANGLE");
                Settings.block.Stretch = Stretch.Fill;
                Skin normalPoints = new NormalPointsDecorator(new DefaultSkin());
                normalPoints.draw();
            }
            return Settings.points;
        }

        /// <summary>
        /// Strategy pattern.
        /// </summary>
        /// <param name="blockCount"></param>
        public int ChangeBlockSpeed(int blockCount)
        {
            if(blockCount == 8)
            {
                b.setStrategy(new MoveFasterSpeed());
                b.changeMovementSpeed();
            }
            else if(blockCount == 15)
            {
                b.setStrategy(new MoveVeryFastSpeed());
                b.changeMovementSpeed();
            }
            return Settings.moveSpeed;
        }

        public void DropBlock()
        {
            if (Canvas.GetTop(Settings.block) < 600 - tower.getLastBlockTop())
            {
                Canvas.SetTop(Settings.block, Canvas.GetTop(Settings.block) + Settings.moveStep);
            }
            else if (tower.isInRange(Canvas.GetLeft(Settings.block)))//blokelis uzsistackino
            {
                IBridge IBridge = this;
                AbstractBridge bridge = new AbstractBridge(IBridge);
                bridge.CallBlockCollision();
            }
            else if (Canvas.GetTop(Settings.block) < 700)//blokelis nukrito
            {
                Canvas.SetTop(Settings.block, Canvas.GetTop(Settings.block) + Settings.moveStep);
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

        public void loseBlock()
        {
            lifes--;
            timer.StopTimer();
            SpawnNewBlock();
            StartBlocksMovement();
        }

        public void MoveBlocksDown()
        {
            if (tower.areBlocksReadyToMoveDown())
            {
                foreach (Image img in blockContainer.getBlocks())
                {
                    Canvas.SetTop(img, Canvas.GetTop(img) + Settings.BlockHeight);
                }
            }
        }


        public void OnButtonKeyDown(object sender, KeyEventArgs e)
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
