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
    public class Window1Tests
    {
        [TestMethod()]
        public void OnButtonKeyDownTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void DropBlockTest()
        {
            Assert.AreEqual(false, isInRange(155, 120));
            Assert.AreEqual(true, isInRange(20, 120));
            Assert.AreEqual(true, isInRange(40, 100));
            Assert.AreEqual(true, isInRange(50, 100));
            Assert.AreEqual(false, isInRange(150, 120));
            Assert.AreEqual(false, isInRange(200, 100));
            Assert.AreEqual(false, isInRange(250, 120));
            Assert.AreEqual(false, isInRange(150, 100));
        }

        public bool isInRange(int x, int blockWidth)
        {
            Console.WriteLine("LAST:{0} -> NOW: {1}", 40, x);
            if (40 == -1) return true;
            if (40 + blockWidth - 20 <= x
                || x + blockWidth - 20 < 40)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [TestMethod()]
        public void ChangeBlockSpeedTest()
        {
            Assert.AreEqual(5, getSpeed(5));
            Assert.AreEqual(8, getSpeed(8));
            Assert.AreEqual(8, getSpeed(-100));

            Assert.Fail();
        }

        public int getSpeed(int x)
        {
            return x;
        }
    }
}