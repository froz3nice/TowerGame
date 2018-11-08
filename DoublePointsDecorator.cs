using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class DoublePointsDecorator : SkinDecorator
    {
        public DoublePointsDecorator(Skin s)
            :base(s)
        {

        }

        public override void draw()
        {
            base.draw();
            setDoublePoints();
        }
        
        private void setDoublePoints()
        {
            Settings.points = 2;
        }
    }
}
