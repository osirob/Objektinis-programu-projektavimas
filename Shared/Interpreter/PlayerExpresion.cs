using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interpreter
{
    public class PlayerExpresion : IExpresion
    {
        GameManagerServer gameManagerServer;
        string playerName;

        public PlayerExpresion(string playerName)
        {
            gameManagerServer = GameManagerServer.Instance;
            this.playerName = playerName;
        }
        public object intepret()
        {
            return gameManagerServer.GetPlayerByName(playerName);
        }
    }
}
