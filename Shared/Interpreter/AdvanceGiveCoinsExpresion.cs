using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interpreter
{
    public class AdvanceGiveCoinsExpresion : IExpresion
    {
        Player player;
        IExpresion ammount;


        public AdvanceGiveCoinsExpresion(Player player, IExpresion ammount)
        {
            this.player = player;
            this.ammount = ammount;
        }

        public object intepret()
        {
            int value = (int)ammount.intepret();
            player.AddMoney(value);
            return null;
        }
    }
}
