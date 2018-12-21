using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame.TemplateMethod
{
    class AlphaPackage : Gift
{
        protected override bool NeedExtraHealth()
        {
            return true;
        }

        protected override bool NeedExtraDoublePoint()
        {
            return true;
        }

        protected override void GiveExtraDoublePoints()
        {
            Settings.totalPoints += 2;
        }

        protected override void GiveExtraHealth()
        {
            Settings.healths += 1;
        }
    }
}
