using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Iterator
{
    public class CoinCollection : IAbstractCollection
    {
        List<Coin> items = new List<Coin>();
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return items.Count; }
        }

        // Indexer
        public Coin this[int index]
        {
            get { return items[index]; }
            set { items.Add(value); }
        }
    }
}
