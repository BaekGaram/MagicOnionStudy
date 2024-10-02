using MagicOnion.Server.Hubs;
using Shared.Interfaces;

namespace Server.StreamingHub;

public partial class GamingHub : StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
{
    public async ValueTask JoinAsync(string userName)
    {
        _gameRoom = await this.Group.AddAsync("GameRoom");
        
        PlayerManager.Instance.AddPlayer(ConnectionId, userName);
        
        BroadCast("Server", $"{userName} is Joined..");
        
        Console.WriteLine($"{userName}:{ConnectionId} is Joined..");
    }
}