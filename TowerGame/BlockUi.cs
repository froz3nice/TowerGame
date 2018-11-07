using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class BlockUi : IBridge
    {
        IBridge Bridge;
        public BlockUi(IBridge bridge)
        {
            this.Bridge = bridge;
        }

        public void BlockCollision()
        {
            Bridge.BlockCollision();
        }
    }
}
