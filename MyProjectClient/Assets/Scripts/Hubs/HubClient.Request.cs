using System.Threading.Tasks;
using Shared.Packets;
using Uitility;

/// <summary>
/// Client -> Server, Request Processor
/// </summary>
public partial class HubClient
{
    public async Task SendMessageAsync(string userName, string message)
    {
        var req = new ReqSendMessagePacket()
        {
            Username = userName,
            Message = message,
        };
        
        var res = await _hub.SendMessage(req);
    }

    public async Task JoinAsync(string userName)
    {
        var req = new ReqJoinPacket()
        {
            Username = userName,
        };

        var res = await _hub.JoinAsync(req);
    }
}