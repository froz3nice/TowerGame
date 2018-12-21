﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    public class TowerConroller
    {
        public double TowerHeightOnScreen = 0;
        public double LastBlockLeftPosition = -1;
        public double LastBlockRightPosition;
        public double LastTowerHeightOnScreen = 0;
        public bool perfectDrop = false;
        public int blockCount = 0;
        public TowerConroller()
        {

        }

        internal void SetTargetRange(double left, double right)
        {
            LastBlockLeftPosition = left;
            LastBlockRightPosition = right;
        }

        internal double getLastBlockTop()
        {
            return TowerHeightOnScreen;
        }

        internal void addHeight(double actualHeight)
        {
            TowerHeightOnScreen += actualHeight;
            blockCount++;
        }

        public bool areBlocksReadyToMoveDown()
        {
            if (blockCount > 3)
            {
                TowerHeightOnScreen -= Settings.BlockHeight;
                return true;
            }
            return false;
        }

        public bool isInRange(double x)
        {
            Console.WriteLine("LAST:{0} -> NOW: {1}", LastBlockLeftPosition, x);
            if (LastBlockLeftPosition == -1) return true;
            if (LastBlockLeftPosition + Settings.BlockWidth - 20 <= x
                || x + Settings.BlockWidth - 20 < LastBlockLeftPosition)
            {
                return false;
            }
            else
            {
                if((x-LastBlockLeftPosition) < 4 && (x - LastBlockLeftPosition) > -4)
                {
                    perfectDrop = true;
                }
                else
                {
                    perfectDrop = false;
                }
                return true;
            }
        }

        public bool getPerfectDrop()
        {
            return perfectDrop;
        }
    }
}
