using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Iterator
{
    internal class Iterator
    {
        CoinCollection collection;
        int current = 0;
        int step = 1;
        // Constructor
        public Iterator(CoinCollection collection)
        {
            this.collection = collection;
        }
        // Gets first item
        public Coin First()
        {
            current = 0;
            return collection[current] as Coin;
        }
        // Gets next item
        public Coin Next()
        {
            current += step;
            if (!IsDone)
                return collection[current] as Coin;
            else
                return null;
        }
        // Gets or sets stepsize
        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        // Gets current iterator item
        public Coin CurrentItem
        {
            get { return collection[current] as Coin; }
        }
        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return current >= collection.Count; }
        }
    }
}
