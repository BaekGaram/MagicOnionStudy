using MagicOnion.Server.Hubs;
using Shared;
using Shared.Interfaces;
using Shared.Packets;

namespace Server.StreamingHub;

public partial class GamingHub : StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
{
    public async ValueTask<ResJoinPacket> JoinAsync(ReqJoinPacket req)
    {
        _gameRoom = await this.Group.AddAsync("GameRoom");
        
        PlayerManager.Instance.AddPlayer(ConnectionId, req.Username);
        
        BroadCastNotification();
        
        return await ValueTask.FromResult(new ResJoinPacket());
    }
}