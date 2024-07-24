using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace MIS.Helpers
{
    public class NotificationService
    {
        private readonly HubConnection _connection;

        public NotificationService()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl($"{FG.Url}/notificationHub")
                .Build();
        }

        public async Task StartAsync()
        {
            await _connection.StartAsync();
        }

        public async Task SendNotificationAsync(string message)
        {
            await _connection.InvokeAsync("SendNotification", message);
        }

        public void OnNotificationReceived(Action<string> handler)
        {
            _connection.On<string>("ReceiveNotification", handler);
        }
    }
}
