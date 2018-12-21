using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class NormalPointsDecorator : SkinDecorator
    {
        public NormalPointsDecorator(Skin s)
            : base(s)
        {

        }


        public void drawEnemy()
        {
            base.draw();
            setNormalPoints();
        }

        public void draw()
        {
            base.draw();
            setNormalPoints();
        }

        public void setNormalPoints()
        {
            Settings.points = 1;
        }

    }
}
