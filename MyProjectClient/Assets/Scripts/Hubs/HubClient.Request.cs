using System.Threading.Tasks;
using Shared.Packets;
using Shared.Util;
using Uitility;

/// <summary>
/// Client -> Server, Request Processor
/// </summary>
public partial class HubClient
{
    public async Task SendMessage(string userName, string message)
    {
        var resultString = (string) await _hub.SendMessage(userName, message);

        // var broadcastPacket = resultString.ToPacket<BroadCastPacket>();
        // MyLogger.Log($"[SendMessage] {broadcastPacket.Message}");
    }

    public async Task Join(string userName)
    {
        await _hub.JoinAsync(userName);
    }
}