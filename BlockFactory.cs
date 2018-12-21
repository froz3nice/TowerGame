using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    public class BlockFactory
    {
        public double getBlock(String shapeType)
        {
            if (shapeType == null)
            {
                return 0 ;
            }
            if (shapeType.Equals("SQUARE"))
            {
                return 100;

            }
            else if (shapeType.Equals("RECTANGLE"))
            {
                return 120;

            }

            return 0;
        }
    }
}
