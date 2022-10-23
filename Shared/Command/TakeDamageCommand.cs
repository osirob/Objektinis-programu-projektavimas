using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Command
{
    public class TakeDamageCommand : ICommand
    {
        private Player player;
        private int damage = 0;

        public TakeDamageCommand(Player player, int damage)
        {
            this.player = player;
            this.damage = damage;
        }
        public void Execute()
        {
            player.TakeDamage(damage);
        }

        public void Undo()
        {
            player.UndoDamage(damage);
        }
    }
}
