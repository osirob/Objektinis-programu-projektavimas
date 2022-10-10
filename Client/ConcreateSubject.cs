using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ConcreateSubject : Subject
    {

        private HubConnection connection;

        public ConcreateSubject()
        {
            this.connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
            _ = StartConectionAsync();
        }

        private async Task StartConectionAsync()
        {
            await connection.StartAsync();
        }
        public override string ReceiveCordinates(string cordinates, string PlayerNumber)
        {
            var returnedCordinates = "";
            connection.On<string>(PlayerNumber, (message) =>
            {
                returnedCordinates = message;
            });
            SendCordinatesAsync(cordinates, PlayerNumber);
            UpdateCord();
        }

        public override async void SendCordinatesAsync(string cordinates, string PlayerNumber)
        {
            string[] cordinatesAlone = cordinates.Split(',');
            await connection.SendAsync(PlayerNumber, cordinatesAlone[0] + "," + cordinatesAlone[1]);
        }
    }
}
