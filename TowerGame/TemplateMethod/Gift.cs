using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame.TemplateMethod
{
    abstract class Gift
    {
        public void MakeGift()
        {
            this.GiveOnePoint();
            if (NeedExtraHealth())
            {
                this.GiveExtraHealth();
            }
            if (NeedExtraDoublePoint())
            {
                this.GiveExtraDoublePoints();
            }
        }

        private void GiveOnePoint()
        {
            Settings.totalPoints += 1;
        }

        protected abstract void GiveExtraHealth();

        protected abstract void GiveExtraDoublePoints();

        protected virtual bool NeedExtraHealth()
        {
            return true;
        }

        protected virtual bool NeedExtraDoublePoint()
        {
            return true;
        }
    }
}
