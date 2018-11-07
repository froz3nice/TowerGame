using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    public class TowerConroller
    {
        double TowerHeightOnScreen = 0;
        double LastBlockLeftPosition = -1;
        double LastBlockRightPosition;
        private double LastTowerHeightOnScreen = 0;
        int blockCount = 0;
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

        internal bool isInRange(double x)
        {
            if (LastBlockLeftPosition == -1) return true;
            if (LastBlockLeftPosition + Settings.BlockWidth - 20 <= x
                || x + Settings.BlockWidth - 20 < LastBlockLeftPosition)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
