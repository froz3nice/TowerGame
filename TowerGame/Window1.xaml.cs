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
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // This list describes the Bonus Red pieces of Food on the Canvas
        private readonly List<Point> _bonusPoints = new List<Point>();

        // This list describes the body of the snake on the Canvas
        private readonly List<Point> _snakePoints = new List<Point>();

        private readonly Brush _snakeColor = Brushes.Green;
        private enum SnakeSize
        {
            Thin = 4,
            Normal = 6,
            Thick = 8
        };
        private enum Movingdirection
        {
            Upwards = 8,
            Downwards = 2,
            Toleft = 4,
            Toright = 6
        };

        //TimeSpan values
        private enum GameSpeed
        {
            Fast = 1,
            Moderate = 10000,
            Slow = 50000,
            DamnSlow = 500000
        };

        private readonly Point _startingPoint = new Point(100, 100);
        private Point _currentPosition = new Point();

        // Movement direction initialisation
        private int _direction = 0;

        /* Placeholder for the previous movement direction
         * The snake needs this to avoid its own body.  */
        private int _previousDirection = 0;

        /* Here user can change the size of the snake. 
         * Possible sizes are THIN, NORMAL and THICK */
        private readonly int _headSize = (int)SnakeSize.Thick;

        private int _length = 100;
        private int _score = 0;    
        private readonly Random _rnd = new Random();

        public Window1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);

            MoveTo(Block1, 100, 100);
        }
        TranslateTransform trans;
        private void MoveTo(Image target, double newX, double newY)
        { 
            var top = Canvas.GetTop(target);
            var left = Canvas.GetLeft(target);
            trans = new TranslateTransform();
            target.RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(top, -400, TimeSpan.FromSeconds(5));
            anim1.RepeatBehavior = RepeatBehavior.Forever;
            anim1.AutoReverse = true;
            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
        }
        //DispatcherTimer timer = new DispatcherTimer();
        //timer.Tick += new EventHandler(timer_Tick);

        ///* Here user can change the speed of the snake. 
        // * Possible speeds are FAST, MODERATE, SLOW and DAMNSLOW */
        //timer.Interval = new TimeSpan((int)GameSpeed.Moderate);
        //timer.Start();

        //PaintSnake(_startingPoint);
        //_currentPosition = _startingPoint;

        //// Instantiate Food Objects
        //for (var n = 0; n < 10; n++)
        //{
        //    PaintBonus(n);
        //}
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    if (trans != null)
                    {
                        trans.BeginAnimation(TranslateTransform.XProperty, null);
                    }
                    Block1.Margin = new Thickness(0, 0, 0, 0);
                    break;

            }

        }



        private void GameOver()
        {
            MessageBox.Show($@"You Lose! Your score is { _score}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Hand);
            this.Close();
        }

      
    }
}
