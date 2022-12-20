using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Iterator
{
    internal interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
}
