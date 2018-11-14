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
        [TestMethod()]
        public void keyPressedTest()
        {
            Assert.AreEqual(true, getKeyName("Return"));
            Assert.AreEqual(true, getKeyName("Escape"));
            Assert.AreEqual(false, getKeyName("blabla"));

        }

        public bool getKeyName(string name)
        {
            if (name.Equals("Return"))
                return true;
            else if (name.Equals("Escape"))
                return true;
            return false;
        }


    }
}