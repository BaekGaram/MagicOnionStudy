using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Client -> Server, Request Processor
/// </summary>
public partial class HubClient
{
    public async Task SendMessage(string userName, string message)
    {
        var resultString = await _hub.SendMessage(userName, message);
        Debug.Log($"[Req] SendMessage result : {resultString}");
    }

    public async Task Join(string userName)
    {
        await _hub.JoinAsync(userName);
        Debug.Log($"[Req] Join : {userName}");
    }
}