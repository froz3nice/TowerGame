using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    public class GameExitCommand : ICommand
    {
        public void execute()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
