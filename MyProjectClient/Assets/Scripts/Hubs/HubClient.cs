using System.Threading.Tasks;
using MagicOnion;
using MagicOnion.Client;
using MagicOnion.Serialization.MemoryPack;
using Uitility;
using UnityEngine;
using Shared.Interfaces;

public partial class HubClient : MonoBehaviourSingletonTemplate<HubClient>, IGamingHubReceiver
{
    private IGamingHub _hub;

    // Start is called before the first frame update
    public async Task Connect(string address)
    {
        if (_hub is not null)
        {
            Debug.LogError("Already connected to MagicOnion Hub");
            return;
        }

        var channel = GrpcChannelx.ForAddress($"{address}");

        _hub = await StreamingHubClient.ConnectAsync<IGamingHub, IGamingHubReceiver>(channel, this,
            serializerProvider: MemoryPackMagicOnionSerializerProvider.Instance);

        if (_hub is null)
        {
            Debug.Log("Failed to connect to SignalR Hub");
            return;
        }
    }

    public void OnJoin(string playerName, float x, float y, float z)
    {
        Debug.Log($"Player {playerName} joined the game");
    }

    public void OnForceClose()
    {
        Debug.Log($"[OnForceClose] errorCode");
    }

    public void OnSendReceiver(string message)
    {
        Debug.Log($"[OnSendReceiver] {message}");
    }

    public async void SendMessage(string userName, string message)
    {
        var resultString = await _hub.SendMessage(userName, message);
        Debug.Log($"SendMessage result : {resultString}");
    }

    public async void Join(string userName)
    {
        await _hub.JoinAsync(userName);
    }
}