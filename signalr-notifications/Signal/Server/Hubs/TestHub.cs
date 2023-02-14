using Microsoft.AspNetCore.SignalR;
using Signal.Shared;

namespace Signal.Server.Hubs;

public class TestHub : Hub<ITestHub>
{
    public async Task ToGroup(string group)
    {
        await Clients.Group(group).ReceiveNotification($"To group {group}");
    }
    
    public async Task JoinGroup(string group)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, group);
    }
}