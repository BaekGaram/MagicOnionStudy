using MagicOnion.Server.Hubs;
using Shared.Interfaces;

namespace Server.StreamingHub;

public class GamingHub: StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
{
    protected override ValueTask OnConnected()
    {
        Console.WriteLine($"[GamingHub:OnConnected] ConnectionId:{ConnectionId} is connected.");
        return ValueTask.CompletedTask;
    }
    
    public ValueTask<Player[]> JoinAsync(string roomName, string userName)
    {
        throw new NotImplementedException();
    }

    public ValueTask LeaveAsync()
    {
        throw new NotImplementedException();
    }
}