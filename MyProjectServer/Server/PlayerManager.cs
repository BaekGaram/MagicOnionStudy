using Shared.Packets;

namespace Server;

public class PlayerManager : Singleton<PlayerManager>
{
    private PlayerManager()
    {
        
    }
    
    private Dictionary<Guid, PlayerInfo> _players { get; set; }  = new Dictionary<Guid, PlayerInfo>();

    public void AddPlayer(Guid connectionId, string userName)
    {
        // 위치값 
        var rnd = new Random();
        
        var randomHexColor = GetRandomHexColor();
        
        var player = new PlayerInfo
        {
            Username = userName,
            X = rnd.Next(-400,400),
            Color = randomHexColor,
        };
        
        _players.TryAdd(connectionId, player);
    }

    public string RemovePlayer(Guid connectionId)
    {
        return _players.TryGetValue(connectionId, out var playerInfo) == true ? playerInfo.Username : playerInfo.Username;
    }

    public bool GetPlayer(Guid contextContextId)
    {
        return _players.TryGetValue(contextContextId, out var playerInfo);
    }
    
    public List<PlayerInfo> GetAllPlayers()
    {
        return _players.Values.ToList();
    }
    
    string GetRandomHexColor()
    {
        // 0x000000 ~ 0xFFFFFF 사이의 숫자를 랜덤으로 생성
        var rnd = new Random();
        
        int r = rnd.Next(0, 256);
        int g = rnd.Next(0, 256);
        int b = rnd.Next(0, 256);
        
        // RGB 값을 헥스코드 문자열로 변환 (예: #RRGGBB)
        return string.Format("#{0:X2}{1:X2}{2:X2}", r, g, b);
    }
}