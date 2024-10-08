using MagicOnion.Server.Hubs;
using Shared.Interfaces;

namespace Server.StreamingHub;

public partial class GamingHub : StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
{
    private IGroup<IGamingHubReceiver> _gameRoom;

    protected override ValueTask OnConnected()
    {
        Console.WriteLine($"[GamingHub:OnConnected] ConnectionId:{ConnectionId} is connected.");
        return ValueTask.CompletedTask;
    }

    protected override ValueTask OnDisconnected()
    {
        PlayerManager.Instance.RemovePlayer(ConnectionId);
        Console.WriteLine($"[GamingHub:OnDisconnected] ConnectionId:{ConnectionId} is disconnected.");

        return ValueTask.CompletedTask;
    }
}