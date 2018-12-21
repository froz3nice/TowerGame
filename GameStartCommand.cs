using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class GameStartCommand : ICommand
    {
        public void execute()
        {
            Window1 win = new Window1();
            win.Show();
            System.Windows.Application.Current.MainWindow.Close();
        }
    }
}
