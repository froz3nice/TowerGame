﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TowerGame
{
    class BlockContainer
    {
        List<Image> blocks;
        public BlockContainer()
        {
            blocks = new List<Image>();
        }

        public List<Image> getBlocks()
        {
            return blocks;
        }

        public void AddBlock(Image block)
        {
            blocks.Add(block);
        }
      
    }
}
