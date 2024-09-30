namespace Server;

public class PlayerManager : Singleton<PlayerManager>
{
    private PlayerManager()
    {
        
    }
    
    private Dictionary<Guid, string> _players { get; set; } = new Dictionary<Guid, string>();

    public void AddPlayer(Guid connectionId, string userName)
    {
        _players.TryAdd(connectionId, userName);
    }

    public string RemovePlayer(Guid connectionId)
    {
        return _players.TryGetValue(connectionId, out var userName) == true ? userName : userName;
    }

    public bool GetPlayer(Guid contextContextId)
    {
        return _players.TryGetValue(contextContextId, out var userName);
    }
}