using System.Threading.Tasks;
using Uitility;

/// <summary>
/// Client -> Server, Request Processor
/// </summary>
public partial class HubClient
{
    public async Task SendMessage(string userName, string message)
    {
        var resultString = await _hub.SendMessage(userName, message);
    }

    public async Task Join(string userName)
    {
        await _hub.JoinAsync(userName);
    }
}