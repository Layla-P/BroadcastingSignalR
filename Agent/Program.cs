using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Agent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:18128/ChatHub")
                .WithAutomaticReconnect()
                .Build();

            await connection.StartAsync();

            string message = Console.ReadLine();

            await connection.InvokeAsync("SendMessage", "Agent", message);

        }
     
    }
}
