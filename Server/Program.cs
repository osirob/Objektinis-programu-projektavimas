using Server.Hubs;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();

app.MapGet("/", () => "This is game server's api");
app.MapHub<GameHub>("/gameHub");
app.Run();

while (true)
{
    Console.Read();
}