using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Iterator
{
    public interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
}
