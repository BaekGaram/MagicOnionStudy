using MagicOnion.Server.Hubs;
using Shared.Interfaces;

namespace Server.StreamingHub;

public partial class GamingHub : StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
{
    public ValueTask<string> SendMessage(string userName, string message)
    {
        var result = "Fail";

        if (PlayerManager.Instance.GetPlayer(Context.ContextId) == true)
        {
            // 이거에 대한 처리를 따로 해줘야함 
            BroadCast(userName, message);
            
            // 이거는 sendMessage에 대한 result 
            result = "SUCCESS";
        }

        return ValueTask.FromResult(result);
    }
}