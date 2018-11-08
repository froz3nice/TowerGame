using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TowerGame
{
    public class BlockContainer
    {
        List<Image> blocks;
        public BlockContainer()
        {
            blocks = new List<Image>();
        }

        public List<Image> getBlocks()//singletonas
        {
            if (blocks == null)
            {
                blocks = new List<Image>();
            }
            return blocks;
        }

        public void AddBlock(Image block)
        {
            blocks.Add(block);
        }

    }
}
