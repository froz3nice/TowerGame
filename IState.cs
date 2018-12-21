using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TowerGame
{
    public interface IState
    {
        void Handle(Block b);
    }
}
