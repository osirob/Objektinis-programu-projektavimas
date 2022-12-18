using Microsoft.AspNetCore.SignalR;
using Shared.Observer;
using Server.Src.Classes;
using Shared.Shared;
using System.Diagnostics;
using Shared.Command;
using System.Threading.Tasks;
using Shared.Bridge;
using System.Timers;
using System.Numerics;
using Shared.Prototype;
using Shared.Mediator;
using Shared.Interpreter;

namespace Server.Hubs
{
    static class GameInfo
    {
        //public static int HowManyIsRead { get; set; } = 0;
        //public static bool GameIsStarted { get; set; } = false;
        //public static int MaxPlayers = 2;

        public static CollectableFactory collectableFactory = new CollectableFactory();
        public static List<Coin> coins = new List<Coin>();
        public static List<Armor> armor = new List<Armor>();
        public static List<HealthPack> healthPacks = new List<HealthPack>();
        public static int coinsRequested = 0;
    }

    //https://localhost:7021/gameHub
    public class GameHub : Hub
    {

        GameManagerServer gameManagerServer;
        CommandInvoker invoker = new CommandInvoker();
        private static Subject subject = new ConcreateSubject();

        DamageReduceBonuses dmgReducesBonus;
        SpeedBonuses speedBonus;
        JumpBonuses jumpBonus;
        ConcreateMediator m;

        Context context;
        ExpresionParser parser;



        public GameHub()
        {
            //TestSingleton();
            gameManagerServer = GameManagerServer.Instance;
            dmgReducesBonus = new DamageReduceBonuses();
            speedBonus = new SpeedBonuses();
            jumpBonus = new JumpBonuses();
            m = new ConcreateMediator(speedBonus, jumpBonus, dmgReducesBonus);
            context = new Context();
            parser = new ExpresionParser(context);
            //Task.Run(WriteCommand);
        }



        //OnlyForTesting
        public void TestSingleton()
        {
            Parallel.Invoke(
                () => CreateSingleton1(),
                () => CreateSingleton2()
                );
            Console.ReadLine();
        }
        public static void CreateSingleton1()
        {
            GameManagerServer singleton1 = GameManagerServer.Instance;
            singleton1.PrintDetails("Singleton1");
        }
        public static void CreateSingleton2()
        {
            GameManagerServer singleton1 = GameManagerServer.Instance;
            singleton1.PrintDetails("Singleton2");
        }
        public async Task RequestCoins()
        {
            if(GameInfo.coinsRequested == 2 && GameInfo.coins.Count == 0)
            {
                GameInfo.coinsRequested = 0;
                for(int i = 1; i < 6; i++)
                {
                    var coin = GameInfo.collectableFactory.MakeCollectable(CollectableFactory.CollectableTypes.Coin, 500, i * 150, 570, i);
                    GameInfo.coins.Add(coin as Coin);
                }
                await Clients.All.SendAsync("sendCoins", GameInfo.coins);
                Console.WriteLine($"Sent coins {GameInfo.coins.Count}");
            }
            else { GameInfo.coinsRequested++; }
        }

        public async Task SendBulletCords(string cords)
        {
            string[] cordsArr = cords.Split(',');

            Console.WriteLine(cords);

            await Clients.Others.SendAsync("bulletCords", cords);
        }

        public async Task RequestFakeCoins()
        {
            
                for (int i = 1; i < 1; i++)
                {
                    var coin = GameInfo.collectableFactory.MakeCollectable(CollectableFactory.CollectableTypes.Coin, 50, i*150 + 40, 570, i + 5);
                    GameInfo.coins.Add(coin as Coin);
                }
                await Clients.All.SendAsync("sendFakeCoins", GameInfo.coins);
                Console.WriteLine($"Sent coins {GameInfo.coins.Count}");

        }

        public async Task GetBonuses(int playerId, string bonusesName)
        {
            switch (bonusesName){
                case "Damage":{
                        dmgReducesBonus.ActivateBoost(playerId);
                    break;
                }
                case "Speed": {
                    speedBonus.ActivateBoost(playerId);
                    break;
                }
                case "Jump":
                {
                    jumpBonus.ActivateBoost(playerId);
                    break;
                }
            }

            Console.WriteLine("Speed " + gameManagerServer.GetPlayer(playerId).Bonuses.SpeedBonus);
            await Clients.Caller.SendAsync("bonuses", gameManagerServer.GetPlayer(playerId).Bonuses);
        }

        public async Task PickedUpCoin(int coinId,int playerId)
        {
            var coin = GameInfo.coins.Where(c => c.Id == coinId).FirstOrDefault();
            if(coin != null)
            {
                ICommand command = new TakeMoneyCommand(gameManagerServer.GetPlayer(playerId),coin.Value);
                invoker.Run(command);
                GameInfo.coins.Remove(coin);
                await Clients.Others.SendAsync("removeCoin", coinId);
            }
        }

        public async Task DecreaseCoins(int value, int playerId)
        {
            Console.WriteLine("DecreaseCoins " + value);
            ICommand command = new TakeMoneyCommand(gameManagerServer.GetPlayer(playerId), value);
            invoker.Run(command);
            return;
        }

        public async Task<Player> ConnectPlayer(string nickname)
        {
            if(gameManagerServer.GetPlayersCount() == 2)
            {
                return null;
            }

            var player = new Player()
            {
                Id = gameManagerServer.GetPlayersCount(),
                Name = nickname,
                isReady = false
            };

            subject.Subscribe(player);
            Console.WriteLine(player.Id);
            gameManagerServer.AddNewPlayer(player);
            //UserHandler.GamePlayers.Add(player);

            await Clients.Others.SendAsync("NewPlayer", player);
            Console.WriteLine($"Player {player.Name} connected!");
            return player;
        }

        public async Task<Player> GetOtherPlayer(int id)
        {

            Player p = gameManagerServer.GetOthersPlayers(id);

            if(p != null)
            {
                return p;
            }

            return null;
        }

        public async Task Die(int id)
        {
            Console.WriteLine("Reached die async id: {0}",id);
            ICommand command = new DieCommand(gameManagerServer.GetPlayer(id));
            invoker.Run(command);
            return;
        }

        public async Task TakeDamage(int id,int damage)
        {
            Console.WriteLine("Reached die async id: {0}", id);
            ICommand command = new TakeDamageCommand(gameManagerServer.GetPlayer(id),damage);
            invoker.Run(command);
            if (id == 1)
            {
                gameManagerServer.GetPlayer(0).AddDamagesBonus(damage,1);
            }
            else
            {
                gameManagerServer.GetPlayer(1).AddDamagesBonus(damage,1);
            }
            return;
        }

        public async Task CheckHowManyOnlineIs(string message)
        {
            Console.WriteLine($"Check recieved: {message}");
            await Clients.All.SendAsync("checkOnline", gameManagerServer.ConnectIDCount());
        }

        public async override Task<Task> OnDisconnectedAsync(Exception exception)
        {
            //UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            gameManagerServer.RemoveConnect(Context.ConnectionId);
            gameManagerServer.SetUnReady(0);
            gameManagerServer.SetUnReady(1);
            //UserHandler.Players[0] = false;
            //UserHandler.Players[1] = false;
            await CheckHowManyOnlineIs("Disconected");
            return base.OnDisconnectedAsync(exception);
        }

        /*
        public async Task AsignPlayer(string message)
        {
            int index = 0;
            if (gameManagerServer.GetIfPlayersAreReady())
            {
                index = 1;
                //UserHandler.Players[0] = true;
                gameManagerServer.SetReady(0);
            }
            else
            {
                index = 2;
                //UserHandler.Players[1] = true;
                gameManagerServer.SetReady(1);
            }
            //Console.WriteLine("PLayer index:" + index); 
            await Clients.Caller.SendAsync("asigningPlayers", index.ToString());
        }
        */
        public async Task CheckHowManyReadyIs(string message)
        {
            //if (!UserHandler.ConnectedIds.Contains(Context.ConnectionId))
            {
                //GameInfo.HowManyIsRead++;
            }
            gameManagerServer.AddReady();
            //Console.WriteLine(GameInfo.HowManyIsRead);
            //Console.WriteLine(UserHandler.ConnectedIds.ToString());
            await Clients.All.SendAsync("checkReady", gameManagerServer.CheckHowManyIsReady().ToString());
        }

        public async Task UndoReady(string message)
        {
            //GameInfo.HowManyIsRead--;
            //Console.WriteLine($"Check recieved: {message}");
            gameManagerServer.RemoveReady();
            await Clients.All.SendAsync("undoReady", gameManagerServer.CheckHowManyIsReady().ToString());
        }

        public async Task RequestUpdateCoins(int id)
        {
            await Clients.Caller.SendAsync("updateCoins", gameManagerServer.GetPlayer(id).HasCoinValue);
        }

        public async Task StartCounting(string message)
        {
            for (int i = 0; i < 3; i++)
            {
                var time = i + 1;
                await Clients.All.SendAsync("counter", time.ToString());
                Thread.Sleep(1000);
            }
            gameManagerServer.SetGameStarted();
            Thread.Sleep(1000);
            await Clients.All.SendAsync("counter", "BEGIN");
        }

        public async Task BuildNewLevel2(int level)
        {
            await Clients.All.SendAsync("level2Map", level);
        }

        public async Task BuildNewLevel3(int level)
        {
            await Clients.All.SendAsync("level3Map", level);
        }

        public async Task ResetReady(string message)
        {
            //GameInfo.HowManyIsRead = 0;
            await Clients.All.SendAsync("resetCount", "Reseted");
        }

        public async Task GetFirtPlayerCordinates(string message)
        {
            await Clients.All.SendAsync("firstPlayer", message);
        }

        public async Task GetSecondPlayerCordinates(string message)
        {
            await Clients.All.SendAsync("secondPlayer", message);
        }

        public async Task SendPlayer1WeaponCoordinatesToPlayer2(string coordinates)
        {
            await Clients.Others.SendAsync("receivePlayer1WeaponCoordinates", coordinates);
        }

        public async Task SendPlayer2WeaponCoordinatesToPlayer1(string coordinates)
        {
            await Clients.Others.SendAsync("receivePlayer2WeaponCoordinates", coordinates);
        }

        public async Task printMessage(string message)
        {
            Console.WriteLine(message);
        }

        public async Task TakeCommand(string commandLine)
        {
            Console.WriteLine("Received command: "+commandLine);
            context.Input = commandLine;
            parser.parse();
            await Clients.Caller.SendAsync("reportAboutCommand", context.Result);
        }

        public async Task RequestUpdateHealth(int id)
        {
            await Clients.Caller.SendAsync("updateHealth", gameManagerServer.GetPlayer(id).Health);
        }


        public void WriteCommand()
        {
            while (true)
            {
                Console.WriteLine("Write your command");
                var text = Console.ReadLine();
                Console.WriteLine(text);
            }
        }
    }
}
