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
    public class TowerConrollerTests
    {
        //Blocks ready to move test
        [TestMethod()]
        public void areBlocksReadyToMoveDownTest_with0Blocks()
        {
            var towerController = new TowerConroller();

            towerController.blockCount = 0;
            var expected = false;

            Assert.AreEqual(expected, towerController.areBlocksReadyToMoveDown());
        }

        [TestMethod()]
        public void areBlocksReadyToMoveDownTest_withMinus5Blocks()
        {
            var towerController = new TowerConroller();

            towerController.blockCount = -5;
            var expected = false;

            Assert.AreEqual(expected, towerController.areBlocksReadyToMoveDown());
        }

        [TestMethod()]
        public void areBlocksReadyToMoveDownTest_with2Blocks()
        {
            var towerController = new TowerConroller();

            towerController.blockCount = 2;
            var expected = false;

            Assert.AreEqual(expected, towerController.areBlocksReadyToMoveDown());
        }

        [TestMethod()]
        public void areBlocksReadyToMoveDownTest_with50Blocks()
        {
            var towerController = new TowerConroller();

            towerController.blockCount = 50;
            var expected = true;

            Assert.AreEqual(expected, towerController.areBlocksReadyToMoveDown());
        }



        //isInRange TEST

        [TestMethod()]
        public void isInRangeTest_perfectPosition()
        {
            var towerController = new TowerConroller();

            var expected = true;
            towerController.LastBlockLeftPosition = 100;
            var actual = towerController.isInRange(100);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void isInRangeTest_badPosition()
        {
            var towerController = new TowerConroller();

            var expected = false;
            towerController.LastBlockLeftPosition = 0;
            var actual = towerController.isInRange(150);

            Assert.AreEqual(expected, actual);
        }
    }
}