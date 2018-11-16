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
        //BLOCK SPEED TEST

        [TestMethod()]
        public void ChangeBlockSpeedTest_block0()
        {
            var windowController = new Window1();

            var expected = 20;

            var actual = windowController.ChangeBlockSpeed(0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ChangeBlockSpeedTest_blockMinus10()
        {
            var windowController = new Window1();

            var expected = 20;

            var actual = windowController.ChangeBlockSpeed(-10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ChangeBlockSpeedTest_block8()
        {
            var windowController = new Window1();

            var expected = 10;

            var actual = windowController.ChangeBlockSpeed(8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ChangeBlockSpeedTest_block15()
        {
            var windowController = new Window1();

            var expected = 1;

            var actual = windowController.ChangeBlockSpeed(15);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ChangeBlockSpeedTest_block16()
        {
            var windowController = new Window1();

            var expected = 1;

            var actual = windowController.ChangeBlockSpeed(16);

            Assert.AreEqual(expected, actual);
        }


        //change skin and give points

        [TestMethod()]
        public void changeSkinTest_onePoint()
        {
            var windowController = new Window1();
            var towerController = new TowerConroller();
            var expected = 1;

            var actual = windowController.changeSkin_forTest(0, towerController);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void changeSkinTest_doublePoints()
        {
            var windowController = new Window1();

            var expected = 2;

            var towerController = new TowerConroller();
            towerController.perfectDrop = true;
            var actual = windowController.changeSkin_forTest(10, towerController);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void changeSkinTest_onePoint2()
        {
            var windowController = new Window1();

            var expected = 1;

            var towerController = new TowerConroller();
            towerController.perfectDrop = false;
            var actual = windowController.changeSkin_forTest(10, towerController);

            Assert.AreEqual(expected, actual);
        }
    }
}