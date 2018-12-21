using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TowerGame.Interpreter;
using TowerGame.Iterator;
using TowerGame.TemplateMethod;

namespace TowerGame
{
    public partial class Window1 : Window, IBridge, IViewUpdator
    {
        //public GameTimer timer { get; set; }
        public Caretaker v;
        public int BlockCount { get; set; } = 0;
        public int EnemyBlockCount { get; set; } = 0;

        public TowerConroller tower { get; set; }
        public BlockContainer blockContainer { get; set; }
        public int lifes = 3;
        public IViewUpdator updater;
        public ICommand c;
        BlockUi blockUi;

        Block b;
        BlockFactory blockFactory = new BlockFactory();
        int points = 0;
        SqlConnection connection;
        BlockContainer iteratorContainer = new BlockContainer();
        public Window1()
        {
            InitializeComponent();
            b = new Block();
            KeyEvent ke = new KeyEvent(this);
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            tower = new TowerConroller();
            blockContainer = new BlockContainer();
            v = new Caretaker();
            health.Content = Settings.healths;
            scoreLabel.Content = Settings.totalPoints;

            SpawnNewBlock();

            AbstractExpression query = new Select("*", new From("users"));
            Context ctx = new Context();
            List<string> result = query.Interpret(ctx);
            Console.WriteLine(result[0]);
            //SpawnNewEnemyBlock();
            StartBlocksMovement();
            //try
            //{

            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //    builder.DataSource = "towerblocks.database.windows.net";
            //    builder.UserID = "towerblocks";
            //    builder.Password = "Qwerty159";
            //    builder.InitialCatalog = "test";
            //    connection = new SqlConnection(builder.ConnectionString);
               
            //    Console.WriteLine("\nQuery data example:");
            //    Console.WriteLine("=========================================\n");

            //    connection.Open();
              
            //    try
            //    {
            //        using (var command = connection.CreateCommand())
            //        {
            //            command.CommandText = "CREATE TABLE blocks (id INTEGER PRIMARY KEY , x INTEGER, username VARCHAR(50));";
            //            command.ExecuteNonQuery();
            //            Console.WriteLine("Finished creating table");
            //        }
            //    }catch(SqlException e)
            //    {
                    
            //    }
            //    System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            //    timer.Tick += ReadEnemyData;
            //    timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            //    timer.Start();
            //    Console.WriteLine(connection.State);
               
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            Console.ReadLine();
        
        //BlockUi = new BlockUi();
    }


        private void ReadEnemyData(object sender, EventArgs e)
        {
            string sql = "SELECT * from blocks where username = 'name'";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetInt32(1)); 
                    }
                }
            }
        }

        public void BlockCollision()
        {
            blockContainer.AddBlock(Settings.block);
            //blockContainer.AddBlock(Settings.enemyBlock);

            tower.addHeight(Settings.BlockHeight);
            tower.SetTargetRange(Canvas.GetLeft(Settings.block), Canvas.GetRight(Settings.block));
            //b.timer.StopTimer();
            SpawnNewBlock();
            StartBlocksMovement();
            Thread.Sleep(100);
            MoveBlocksDown();
        }

        public void updateCanvas(double x)
        {
            Canvas.SetLeft(Settings.block, x);
        }

        public void updateEnemyCanvas(double x)
        {
            //Canvas.SetLeft(Settings.enemyBlock, x + 500);
        }

        public void StartBlocksMovement()
        {
            b.GoNext();
            //b.timer = new GameTimer(Settings.MOVE_TIMER,b);
        }

        public void StartBlockDrop()
        {
            b.GoNext();
            //b.timer = new GameTimer(Settings.DROP_TIMER,b);
        }


        private void SpawnNewEnemyBlock()
        {
            Settings.enemyBlock = new Image();
            changeEnemySkin(EnemyBlockCount);
            EnemyBlockCount++;
            Settings.enemyBlock.Name = "enemyBlock" + BlockCount.ToString();
            Settings.enemyBlock.Height = Settings.BlockHeight;
            Settings.enemyBlock.Width = Settings.BlockWidth;
            Settings.enemyBlock.Stretch = Stretch.Fill;
            Canvas.SetLeft(Settings.enemyBlock, 30 + 500);
            Canvas.SetTop(Settings.enemyBlock, 0);
            AddNewBlock(Settings.enemyBlock);
            created = false;
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
            created = false;
        }

        private int changeEnemySkin(int blockCount)
        {
            if (blockCount == 0)
            {
                Skin normalPoints = new NormalPointsDecorator(new DefaultSkin());
                normalPoints.drawEnemy();
            }
            else if (tower.getPerfectDrop())
            {
                Settings.BlockWidth = blockFactory.getBlock("SQUARE");
                Settings.enemyBlock.Stretch = Stretch.Fill;
                Skin doublePoints = new DoublePointsDecorator(new DoublePointsSkin());
                doublePoints.drawEnemy();
            }
            else
            {
                Settings.BlockWidth = blockFactory.getBlock("RECTANGLE");
                Settings.enemyBlock.Stretch = Stretch.Fill;
                Skin normalPoints = new NormalPointsDecorator(new DefaultSkin());
                normalPoints.drawEnemy();
            }
            return Settings.points;
        
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
        bool created = false;
        public void DropBlock()
        { 
            if (Canvas.GetTop(Settings.block) < 600 - tower.getLastBlockTop())
            {
                Canvas.SetTop(Settings.block, Canvas.GetTop(Settings.block) + Settings.moveStep);
            }
            else if (tower.isInRange(Canvas.GetLeft(Settings.block)))//blokelis uzsistackino
            {
                Random rnd = new Random();
                int gift_num = rnd.Next(0, 10);
                Settings.totalPoints += 1;
                if (gift_num < 2)
                {
                    Gift g = new BravoPackage();
                    g.MakeGift();
                }
                if (gift_num == 9)
                {
                    Gift g = new AlphaPackage();
                    g.MakeGift();
                }
                health.Content = Settings.healths;
                scoreLabel.Content = Settings.totalPoints;
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
                Settings.healths -= 1;
                health.Content = Settings.healths;
                if (Settings.healths < 1)
                {
                    this.Close();
                }
            }
        }

        public void AddNewBlock(Image Block)
        {
            canvas.Children.Add(Block);
        }

        public void loseBlock()
        {
            lifes--;
            //b.timer.StopTimer();
            SpawnNewBlock();
            StartBlocksMovement();
        }

        public void MoveBlocksDown()
        {
            if (tower.areBlocksReadyToMoveDown())
            {
                IIterator i = blockContainer.CreateIterator();
                object block = i.First();
                while (block != null)
                {
                    Canvas.SetTop((Image)block, Canvas.GetTop((Image)block) + Settings.BlockHeight);
                    block = i.Next();
                }
            }
        }


        public void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    //b.timer.StopTimer();
                    StartBlockDrop();
                    break;
                case Key.A:
                    v.Memento = blockContainer.CreateMemento();
                    Console.WriteLine("Sukurta kopija");
                    break;
                case Key.S:
                    Console.WriteLine("Grazinta kopija");
                    blockContainer.SetMemento(v.Memento);
                    break;
                case Key.F:
                    Settings.healths--;
                    int before = 0;
                    for (int i = 0; i < canvas.Children.Count; i++)
                    {
                        if (Canvas.GetTop(canvas.Children[i]) != 0)
                        {
                            canvas.Children.Remove(canvas.Children[i]);
                            before++;
                            i--;
                        }
                    }
                    foreach (Image i in blockContainer.getBlocks())
                        canvas.Children.Add(i);
                    if (blockContainer.getBlocks().Count <= 3)
                    {
                        tower.TowerHeightOnScreen -= Settings.BlockHeight * (before - blockContainer.getBlocks().Count);
                        tower.blockCount = blockContainer.getBlocks().Count;
                    }
                    else
                        for (int j = 0; j < before - canvas.Children.Count + 1; j++)
                        {
                            foreach (Image img in blockContainer.getBlocks())
                            {
                                Canvas.SetTop(img, Canvas.GetTop(img) - Settings.BlockHeight);
                            }

                        }
                    

                    break;
                
            }
        }

        private void GameOver()
        {
            // MessageBox.Show($@"You Lose! Your score is { _score}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Hand);
            this.Close();
        }

        public void DropEnemyBlock()
        {
            throw new NotImplementedException();
        }

    }
}
