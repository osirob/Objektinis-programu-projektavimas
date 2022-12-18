using Microsoft.AspNetCore.SignalR.Client;
using System;

public class Program
{
    //[username] give coins [ammount]
    //[username] give health [ammount]
    static HubConnection connection;
    public static void Main()
    {
        Console.WriteLine("Write Your command");
        {
            SetUp();
            while (true)
            {
                var text = Console.ReadLine();
                if(text == null)
                {
                    Console.WriteLine("Command was not send because its empty");
                }
                else
                {
                    _ = SendMessageAsync(text);
                    Console.WriteLine("Command was sended");
                }

            }   
        }
    }


    public static void SetUp()
    {
        _ = ConnectAsync();
    }
    static async Task ConnectAsync()
    {
        connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
        await connection.StartAsync();
    }


    public static async Task SendMessageAsync(string message)
    {
        connection.On<string>("reportAboutCommand", result =>
        {
            Console.WriteLine("Report: " + result);


        });

        await connection.SendAsync("TakeCommand", message);
    }




}