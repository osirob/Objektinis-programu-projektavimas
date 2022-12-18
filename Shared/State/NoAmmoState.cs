using System;
using System.Collections.Generic;
using System.Text;
using Shared.Shared;

namespace Shared.State
{
    public class NoAmmoState : PlayerState
    {
        public override int HandleMovement()
        {
            int movement = 2;
            return movement;
        }
    }
}
