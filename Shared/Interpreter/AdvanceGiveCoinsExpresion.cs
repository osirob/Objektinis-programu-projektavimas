using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interpreter
{
    public class AdvanceGiveCoinsExpresion : Expresion
    {
        Player player;
        Expresion ammount;


        public AdvanceGiveCoinsExpresion(Player player, Expresion ammount)
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
