using UnityEngine;
using Shared.Packets;
using Unity.VisualScripting;

public partial class HubClient
{
    public void OnSendReceiver(BroadCastPacket pkt)
    {
        // 여기서 broadcast 패킷 처리 
        Debug.Log($"[OnSendReceiver] {pkt.Sender} : {pkt.Message}");
        
        GameManager.Instance.ShowMessage(pkt.Sender, pkt.Message);
    }
    
    public void OnJoinNotificationReceiver(JoinNotiPacket pkt)
    {
        // 여기서 notification 패킷 처리
        Debug.Log($"[OnNotificationReceiver] ");

        foreach (var player in pkt.Players)
        {
            GameManager.Instance.ShowGamePlayer(player.Username, player.X, player.Color);    
        }
    }   
}