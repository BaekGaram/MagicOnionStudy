using UnityEngine;

public partial class HubClient
{
    public void OnForceClose()
    {
        Debug.Log($"[OnForceClose]");
    }

    public void OnSendReceiver(string message)
    {
        Debug.Log($"[OnSendReceiver] {message}");
    }
}