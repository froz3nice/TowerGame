using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TowerGame
{
    public interface IViewUpdator
    {
        void updateCanvas(double x);
        void updateEnemyCanvas(double x);
        void AddNewBlock(Image block);
        void DropBlock();
        void DropEnemyBlock();

    }
}
