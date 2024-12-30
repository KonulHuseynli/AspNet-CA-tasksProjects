using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task AddToGroup(string group)
        {
          await  Groups.AddToGroupAsync(Context.ConnectionId,group);
        }
        public async Task RemoveFromGroup(string group)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        }



        public async Task SendMessage(string group,string user, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", user, message);
        }

        //context-connection id gelir icinde
    }
}