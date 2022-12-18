using System;
using System.Collections.Generic;
using System.Text;
using Shared.Shared;

namespace Shared.State
{
    public class LowHealthState : PlayerState
    {
        public override int HandleMovement()
        {
            int movement = 30;
            return movement;
        }
    }
}
