using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Command
{
    public class TakeMoneyCommand : ICommand
    {
        private Player player;
        private int amount;
        public TakeMoneyCommand(Player player, int amount)
        {
            this.player = player;
            this.amount = amount;
        }
        public void Execute()
        {
            player.AddMoney(amount);
        }

        public void Undo()
        {
            player.AddMoney(-1 * amount);
        }
    }
}
