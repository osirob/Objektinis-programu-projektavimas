using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Command
{
    public class DieCommand : ICommand
    {
        private Player player;
        public DieCommand(Player player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.Die();
        }

        public void Undo()
        {
            player.Revive();
        }
    }
}
