using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TowerGame.Iterator;

namespace TowerGame
{
    public class BlockContainer : Aggregate
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
        // Creates memento 
        public Memento CreateMemento()
        {
            return (new Memento(blocks));
        }

        // Restores original state
        public void SetMemento(Memento memento)
        {
            blocks.Clear();
            Console.WriteLine("Restoring state...");
            foreach (Image i in memento.block)
            {
                blocks.Add(i);
            }
        }

        public override IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        // Gets item count

        public int Count
        {
            get { return blocks.Count; }
        }

        // Indexer

        public object this[int index]
        {
            get { return blocks[index]; }
        }
    }



}

