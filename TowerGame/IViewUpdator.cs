using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    interface IViewUpdator
    {
        void updateCanvas(double x);
        void DropBlock();
    }
}
