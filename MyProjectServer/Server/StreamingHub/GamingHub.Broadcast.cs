using MagicOnion.Server.Hubs;
using Shared.Interfaces;
using Shared.Packets;
using Shared.Util;

namespace Server.StreamingHub;

public partial class GamingHub : StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
{
    private void BroadCast(string name, string message)
    {
        var pkt = new BroadCastPacket()
        {
            Sender = name,
            Message = message,
        };

        _gameRoom.All.OnSendReceiver(pkt);
        Console.WriteLine($"[Broadcast]::{name}:{message}");
    }

    private void BroadCastNotification()
    {
        var pkt = new JoinNotiPacket
        {
            Players = PlayerManager.Instance.GetAllPlayers()
        };

        _gameRoom.All.OnJoinNotificationReceiver(pkt);

        Console.WriteLine($"[NotificationReceiver]:cnt::{pkt.Players.Count}");
    }
}