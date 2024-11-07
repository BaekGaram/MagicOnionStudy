using MagicOnion.Server.Hubs;
using Shared.Interfaces;

namespace Server.StreamingHub;

public partial class GamingHub : StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
{
    public async ValueTask LeaveAsync()
    {
        await _gameRoom.RemoveAsync(this.Context);
        //var userName = PlayerManager.Instance.RemovePlayer(this.Context.ContextId);
        //BroadCast("Server", $"{userName} leaved..");
    }
}