using System.Threading.Tasks;
using MagicOnion;
using MessagePack;

namespace Shared.Interfaces
{
    public interface IGamingHubReceiver
    {
        void OnJoin(Player player);
        void OnLeave(Player player);
        void OnMove(Player player);
    }
    
    public interface IGamingHub : IStreamingHub<IGamingHub, IGamingHubReceiver>
    {
        ValueTask<Player[]> JoinAsync(string roomName, string userName);
        ValueTask LeaveAsync();
    }
    
    [MessagePackObject]
    public class Player
    {
        [Key(0)]
        public string Name { get; set; }
    }
}