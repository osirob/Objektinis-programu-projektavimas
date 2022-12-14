using Shared.Bridge;
using Shared.Builder;
using Shared.Prototype;
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
        private static Map map2 = null;
        private static Map map3 = null;

        public static bool openedUpdater = false;

        public static int currLevel = 1;

        //private static CollectableFactory collectableFactory = new CollectableFactory();

        private GameManagerServer()
        {
            counter++;
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
                        instance.BuildMap();
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

        public Player? GetPlayerByName(string name)
        {
            foreach(var pl in GamePlayers)
            {
                if(pl.Name == name)
                {
                    return pl;
                }
            }
            return null;
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

            MapBuilder mapBuilder2 = new SecondLevelMapBuilder();
            MapDirector mapDirector2 = new MapDirector(mapBuilder2);
            mapDirector2.buildMap();
            map2 = mapDirector2.getMap();

            MapBuilder mapBuilder3 = new ThirdLevelMapBuilder();
            MapDirector mapDirector3 = new MapDirector(mapBuilder3);
            mapDirector3.buildMap();
            map3 = mapDirector3.getMap();
        }

        public Map GetMap()
        {
            return map;
        }
        public Map GetMap2()
        {
            return map2;
        }
        public Map GetMap3()
        {
            return map3;
        }

        public List<MapObject> GetFloatingPlatforms()
        {
            return map.getFloatingPlatforms();
        }
    }
}
