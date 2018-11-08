using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class DefaultSkin : Skin
    {
        public void draw()
        {
            Settings.setBlock(0);
        }
    }
}
