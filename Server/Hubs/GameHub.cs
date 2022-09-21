using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{

    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
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
    }
}
