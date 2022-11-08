using Shared.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public sealed class GameManagerServer
    {
        private static GameManagerServer instance = null;

        private static readonly object padlock = new object();


        private static HashSet<string> ConnectedIds = new HashSet<string>();

        private static bool[] PlayersReady = new bool[2];

        private static List<Player> GamePlayers = new List<Player>();


        private static int HowManyIsRead = 0;
        private static bool GameIsStarted = false;
        private static int counter = 0;

        private static Map map = null;

        //private static CollectableFactory collectableFactory = new CollectableFactory();

        private GameManagerServer()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());

            BuildMap();
        }

        public static GameManagerServer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameManagerServer();
                    }
                    return instance;
                }
            }
        }


        public void AddConnectID(string id)
        {
            ConnectedIds.Add(id);
        }

        public void RemoveConnect(string id)
        {
            ConnectedIds.Add(id);
        }

        public int ConnectIDCount()
        {
            return ConnectedIds.Count();
        }

        public void SetReady(int id)
        {
            PlayersReady[id] = true;
        }

        public void SetUnReady(int id)
        {
            PlayersReady[id] = false;
        }

        //Later need to edit
        public bool GetIfPlayersAreReady()
        {
            bool check = false;

            /**
            foreach(bool isReady in PlayersReady)
            {

            }
            */
            
            return PlayersReady[0];
        }

        public int GetPlayersCount()
        {
            return GamePlayers.Count;
        }

        public void AddNewPlayer(Player player)
        {
            GamePlayers.Add(player);
        }

        //Later needs edit
        public Player GetOthersPlayers(int id)
        {
            foreach (Player p in GamePlayers)
            {
                if (p.Id != id)
                {
                    return p;
                }
            }

            return null;
        }

        public int CheckHowManyIsReady()
        {
            return HowManyIsRead;
        }

        public void AddReady()
        {
            HowManyIsRead++;
        }

        public void RemoveReady()
        {
            HowManyIsRead--;
        }

        public void SetGameStarted()
        {
            GameIsStarted = true;
        }

        public Player GetPlayer(int id)
        {
            return GamePlayers[id];
        }

        //Only for testing purpose
        public void PrintDetails(string text)
        {
            Console.WriteLine(text);
        }

        private void BuildMap()
        {
            MapBuilder mapBuilder = new FirstLevelMapBuilder();
            MapDirector mapDirector = new MapDirector(mapBuilder);
            mapDirector.buildMap();
            map = mapDirector.getMap();
        }

        public Map GetMap()
        {
            return map;
        }
    }
}
