using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame.Tests
{
    [TestClass()]
    public class KeyEventTests
    {

        //keyPressed test

        [TestMethod()]
        public void keyPressedTest_returnKey()
        {
            var keyController = new KeyEvent(new Window1());
            var expected = "Return";
            keyController.keyPressedForTest("Return");
            var actual = keyController.keyAssigned;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void keyPressedTest_escapeKey()
        {
            var keyController = new KeyEvent(new Window1());
            var expected = "Escape";
            keyController.keyPressedForTest("Escape");
            var actual = keyController.keyAssigned;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void keyPressedTest_wrongKey()
        {
            var keyController = new KeyEvent(new Window1());
            var expected = "";
            keyController.keyPressedForTest("");
            var actual = keyController.keyAssigned;
            Assert.AreEqual(expected, actual);
        }
    }
}