using MagicOnion.Server.Hubs;
using Server.Packets;
using Shared.Interfaces;
using Shared.Packets;
using Shared.Util;

namespace Server.StreamingHub;

public partial class GamingHub: StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
{
    private IGroup<IGamingHubReceiver> _gameRoom;
    
    protected override ValueTask OnConnected()
    {
        Console.WriteLine($"[GamingHub:OnConnected] ConnectionId:{ConnectionId} is connected.");
        return ValueTask.CompletedTask;
    }

    protected override ValueTask OnDisconnected()
    {
        Console.WriteLine($"[GamingHub:OnDisconnected] ConnectionId:{ConnectionId} is disconnected.");
        return ValueTask.CompletedTask;
    }

    private void BroadCast(string name, string message)
    {
        var broadCastPacket = new BroadCastPacket()
        {
            Sender = name,
            Message = message,
        };
        
        _gameRoom.All.OnSendReceiver(broadCastPacket.ToJson());
        
        Console.WriteLine($"broadcast::{name}:{message}");
    }
}