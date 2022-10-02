using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public sealed class GameManager
    {
        private static GameManager instance = null;
        private static readonly object padlock = new object();
        private Player player1 = null;
        private Player player2 = null;
        private bool GameIsStarted = false;

        private GameManager()
        {

        }

        public static GameManager Instance { 
            get {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new GameManager();
                    }
                    return instance;
                }
            } 
        }

        public void SetPlayer(Player player, bool ItsMe)
        {
            lock (padlock)
            {

                if (ItsMe)
                {
                    player1 = player;
                }
                else
                {
                    player2 = player;
                }
            }
        }


        public int GetYourId()
        {
            return player1.Id;
        }

        public string GetName()
        {
            return player1.Name;
        }

        /**
        public void SetPlayerName(string name,bool isYourName)
        {
            if (isYourName)
            {
                player1.Name = name;
            }
            else
            {
                player2.Name = name;
            }
        }

        public void SetPlayerId(int id, bool isYourId)
        {
            if (isYourId)
            {
                player1.Id = id;
            }
            else
            {
                player2.Id = id;
            }
        }
        */


    }
}
