using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interpreter
{
    public class AdvanceGiveHealthExpresion : IExpresion
    {
        Player player;
        IExpresion ammount;


        public AdvanceGiveHealthExpresion(Player player, IExpresion ammount)
        {
            this.player = player;
            this.ammount = ammount;
        }

        public object intepret()
        {
            int value = (int)ammount.intepret();
            player.TakeDamage(value*-1);
            return null;
        }
    }
}
