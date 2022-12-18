using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public abstract class PlayerState
    {
        protected Player _player;

        public abstract int HandleMovement();
    }
}
