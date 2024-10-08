using MagicOnion.Server.Hubs;
using Shared.Interfaces;
using Shared.Packets;

namespace Server.StreamingHub;

public partial class GamingHub : StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
{
    public ValueTask<ResSendMessagePacket> SendMessage(ReqSendMessagePacket req)
    {
        var res = new ResSendMessagePacket();

        if (PlayerManager.Instance.GetPlayer(Context.ContextId) == true)
        {
            // 이거에 대한 처리를 따로 해줘야함 
            BroadCast(req.Username, req.Message);
            
        }

        return ValueTask.FromResult(res);
    }
}