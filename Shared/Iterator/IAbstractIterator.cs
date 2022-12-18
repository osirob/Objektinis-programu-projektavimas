using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Iterator
{
    public interface IAbstractIterator
    {
        Coin First();
        Coin Next();
        bool IsDone { get; }
        Coin CurrentItem { get; }
    }
}
