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
    class Settings
    {
        public static int max_x_to_right = 300;
        public static int max_x_to_left = 46;
        public static int moveSpeed = 20;
        public static int dropSpeed = 5;
        public static int moveStep = 5;
        public static int moveSpeedEnemy = 20;
        public static int dropSpeedEnemy = 5;
        public static int moveStepEnemy = 5;
        public static string MOVE_TIMER = "MOVE_TIMER";
        public static string DROP_TIMER = "DROP_TIMER";

        public static int points = 1;

        public static double BlockHeight = 80;

        public static double BlockWidth = 120;

        public static Image block { get; set; }
        public static Image enemyBlock { get; set; }

        public static void setEnemyBlock(int skinId)
        {
            if (skinId == 0)
            {
                enemyBlock.Source = new BitmapImage(new Uri(@"\block.png", UriKind.Relative));
            }
            else if (skinId == 1)
            {
                enemyBlock.Source = new BitmapImage(new Uri(@"\block2.png", UriKind.Relative));
            }
        }

        public static void setBlock(int skinId)
        {
            if(skinId == 0)
            {
                block.Source = new BitmapImage(new Uri(@"\block.png", UriKind.Relative));
            }
            else if(skinId == 1)
            {
                block.Source = new BitmapImage(new Uri(@"\block2.png", UriKind.Relative));
            }
        }

    }
}
