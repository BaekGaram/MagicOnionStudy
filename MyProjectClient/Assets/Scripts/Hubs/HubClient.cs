using System.Threading.Tasks;
using MagicOnion;
using MagicOnion.Client;
using MagicOnion.Serialization.MemoryPack;
using Uitility;
using Shared.Interfaces;

public partial class HubClient : MonoBehaviourSingletonTemplate<HubClient>, IGamingHubReceiver
{
    private IGamingHub _hub;

    // Client -> Server Connect
    public async Task<bool> Connect(string address)
    {
        var channel = GrpcChannelx.ForAddress($"{address}");

        _hub = await StreamingHubClient.ConnectAsync<IGamingHub, IGamingHubReceiver>(channel, this,
            serializerProvider: MemoryPackMagicOnionSerializerProvider.Instance);

        if (_hub is null)
        {
            MyLogger.Log("Failed to connect to Hub");
            return false;
        }
        
        return true;
    }
    
    // Disconnect
    public async Task DisposeAsync()
    {
        await _hub.DisposeAsync();
    }
    
}