using UnityEngine;

public partial class HubClient
{
    public void OnForceClose()
    {
        Debug.Log($"[OnForceClose]");
    }

    public void OnSendReceiver(string message)
    {
        // 여기서 broadcast 패킷 처리 
        Debug.Log($"[OnSendReceiver] {message}");
    }
}