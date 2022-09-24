using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();

    }

    static class GameInfo
    {
        public static int HowManyIsRead { get; set; } = 0;
        public static bool GameIsStarted { get; set; } = false;
    }

    //https://localhost:7021/gameHub
    public class GameHub : Hub
    {
        public async Task SendMessage(string message)
        {
            Console.WriteLine($"Message recieved: {message}");
            await Clients.All.SendAsync("recievingMessage", message);
        }

        public async override Task<Task> OnConnectedAsync()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            await CheckHowManyOnlineIs("Connected");
            return base.OnConnectedAsync();
        }

        public async override Task<Task> OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            await CheckHowManyOnlineIs("Disconected");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task CheckHowManyOnlineIs(string message)
        {
            Console.WriteLine($"Check recieved: {message}");
            await Clients.All.SendAsync("checkOnline", UserHandler.ConnectedIds.Count.ToString());
        }

        public async Task CheckHowManyReadyIs(string message)
        {
            //if (!UserHandler.ConnectedIds.Contains(Context.ConnectionId))
            {
                GameInfo.HowManyIsRead++;
            }
            Console.WriteLine(GameInfo.HowManyIsRead);
            await Clients.All.SendAsync("checkReady", GameInfo.HowManyIsRead.ToString());
        }

        public async Task UndoReady(string message)
        {
            GameInfo.HowManyIsRead--;
            //Console.WriteLine($"Check recieved: {message}");
            await Clients.All.SendAsync("undoReady", GameInfo.HowManyIsRead.ToString());
        }

        public async Task StartCounting(string message)
        {
            for(int i = 0; i < 3; i++)
            {
                var time = i + 1;
                await Clients.All.SendAsync("counter", time.ToString());
                Thread.Sleep(1000);
            }
            GameInfo.GameIsStarted = true;
            Thread.Sleep(1000);
            await Clients.All.SendAsync("counter", "BEGIN");
        }

        public async Task ResetReady(string message)
        {
            GameInfo.HowManyIsRead = 0;
            await Clients.All.SendAsync("resetCount", "Reseted");
        }
    }
}
