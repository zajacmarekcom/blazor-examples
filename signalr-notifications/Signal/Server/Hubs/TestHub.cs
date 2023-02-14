using Microsoft.AspNetCore.SignalR;

namespace Signal.Server.Hubs;

public class TestHub : Hub
{
    public async Task ActionFinished(string group)
    {
        await Clients.Group(group).SendAsync("ReceiveNotification");
    }
    
    public async Task JoinGroup(string group)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, group);
    }
}