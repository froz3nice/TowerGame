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
    public class BlockFactoryTests
    {
        [TestMethod()]
        public void getBlockTest_square()
        {
            var blockController = new BlockFactory();
            var expected = 100;

            var actual = blockController.getBlock("SQUARE");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getBlockTest_rectangle()
        {
            var blockController = new BlockFactory();
            var expected = 120;

            var actual = blockController.getBlock("RECTANGLE");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getBlockTest_null()
        {
            var blockController = new BlockFactory();
            var expected = 0;

            var actual = blockController.getBlock("");

            Assert.AreEqual(expected, actual);
        }
    }
}