using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    public abstract class SkinDecorator : Skin
    {
        protected Skin decoratedSkin;

        public SkinDecorator(Skin s)
        {
            this.decoratedSkin = s;
        }

        public virtual void draw()
        {
            decoratedSkin.draw();
        }
    }
}
