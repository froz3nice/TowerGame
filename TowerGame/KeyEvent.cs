using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TowerGame
{
    public class KeyEvent
    {
        private ICommand Ic;

        public string key = "";

        private Control _control;

        public KeyEvent(Control control)
        {
            _control = control;

            _control.KeyDown += keyPressed;
        }

        public void keyPressed(object sender, KeyEventArgs e)
        {
            key = e.Key.ToString();
            if (key.Equals("Return"))
                Ic = new GameStartCommand();
            else if (key.Equals("Escape"))
                Ic = new GameExitCommand();
            if (Ic != null) 
            Ic.execute();
            Console.WriteLine(key);
            
        }

    }
}
