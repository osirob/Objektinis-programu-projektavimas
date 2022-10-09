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
        public override void ReceiveCordinates(string cordinates, string PlayerNumber)
        {
            throw new NotImplementedException();
        }

        public override void SendCordinates(string cordinates, string PlayerNumber)
        {
            throw new NotImplementedException();
        }
    }
}
