using System;
using System.Collections.Generic;
using System.Text;
using Shared.Shared;
using Shared.State;

namespace Shared.State
{
    public class ShoppingState : PlayerState
    {
        public override int HandleMovement()
        {
            int movement = 5;
            return movement;
        }
    }
}
