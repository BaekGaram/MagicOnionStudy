using System.Threading.Tasks;
using MagicOnion;
using Shared.Packets;

namespace Shared.Interfaces
{
    /// <summary>
    /// Server -> client definition
    /// </summary>
    public interface IGamingHubReceiver
    {
        void OnSendReceiver(BroadCastPacket packet);
        void OnJoinNotificationReceiver(JoinNotiPacket packet);
    }
    
    /// <summary>
    /// Client -> Server, packet processor
    /// The server program must implement this interface.
    /// </summary>
    public interface IGamingHub : IStreamingHub<IGamingHub, IGamingHubReceiver>
    {
        ValueTask LeaveAsync();
        ValueTask<ResJoinPacket> JoinAsync(ReqJoinPacket req);
        ValueTask <ResSendMessagePacket> SendMessage(ReqSendMessagePacket req);
    }
}