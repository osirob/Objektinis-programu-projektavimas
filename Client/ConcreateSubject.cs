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
        private string CoorinatesOfPlayer = "";
       
        public ConcreateSubject()
        {
            this.connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
            _ = StartConectionAsync();
        }

        private async Task StartConectionAsync()
        {
            await connection.StartAsync();
        }
        public override void ReceiveCordinates(string cordinates, string PlayerNumber)
        {
            string WhichReceive = "";
            string WhichSend = "";
            if (Convert.ToInt32(PlayerNumber) == 0)
            {
                WhichReceive = "SecondPlayer";
                WhichSend = "FirstPlayer";

            }
            else
            {
                WhichReceive = "FirstPlayer";
                WhichSend = "SecondPlayer";
            }
            connection.On<string>(WhichReceive, (message) =>
            {
                CoorinatesOfPlayer = message;
                UpdateCord(CoorinatesOfPlayer);
            });
            SendCordinatesAsync(cordinates, WhichSend);

        }

        public override async void SendCordinatesAsync(string cordinates, string PlayerNumber)
        {
            string[] cordinatesAlone = cordinates.Split(',');
            await connection.SendAsync(PlayerNumber, cordinatesAlone[0] + "," + cordinatesAlone[1]);
        }
    }
}
