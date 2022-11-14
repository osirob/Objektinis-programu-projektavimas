using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Prototype
{
    public interface MapObject
    {
        public MapObject makeCopy();
    }
}
