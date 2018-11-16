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
        public string keyAssigned = "";

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
            {
                Ic = new GameStartCommand();
                keyAssigned = key;
            }


            else if (key.Equals("Escape"))
            {
                Ic = new GameExitCommand();
                keyAssigned = key;
            }

            if (Ic != null) 
            Ic.execute();
        }

        public void keyPressedForTest(string keySent)
        {
            key = keySent;
            if (key.Equals("Return"))
            {
                keyAssigned = key;
            }
            else if (key.Equals("Escape"))
            {
                keyAssigned = key;
            }
            if (Ic != null)
                Ic.execute();
        }

    }
}
