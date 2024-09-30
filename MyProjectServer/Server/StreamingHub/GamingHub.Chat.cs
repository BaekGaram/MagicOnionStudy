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
            BroadCast(userName, message);
            result = "SUCCESS";
        }

        return ValueTask.FromResult(result);
    }
}