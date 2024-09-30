using System.Threading.Tasks;
using MagicOnion;

namespace Shared.Interfaces
{
    /// <summary>
    /// Server -> client definition
    /// </summary>
    public interface IGamingHubReceiver
    {
        void OnSendReceiver(string message);
    }
    
    /// <summary>
    /// Client -> Server, packet processor
    /// The server program must implement this interface.
    /// </summary>
    public interface IGamingHub : IStreamingHub<IGamingHub, IGamingHubReceiver>
    {
        ValueTask JoinAsync(string userName);
        ValueTask LeaveAsync();
        ValueTask <string> SendMessage(string userName, string message);
    }
}