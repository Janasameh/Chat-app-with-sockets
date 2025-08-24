using Microsoft.AspNetCore.SignalR;

namespace MyFirstApi.Hubs   // <-- change this to match your project
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
