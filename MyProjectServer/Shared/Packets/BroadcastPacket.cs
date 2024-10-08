using System.Collections.Generic;
using MemoryPack;

namespace Shared.Packets
{
    [MemoryPackable]
    public partial class BroadCastPacket : BaseResponsePacket
    {
        public string Sender { get; set; }
        public string Message { get; set; }
    }

    [MemoryPackable]
    public partial class NotificationPacket : BaseResponsePacket
    {
        public string Sender { get; set; }
        public string Message { get; set; }
    }
    
    [MemoryPackable]
    public partial class JoinNotiPacket : BaseResponsePacket
    {
        public List<PlayerInfo> Players { get; set; }
    }

    [MemoryPackable]
    public partial class PlayerInfo
    {
        public string Username { get; set; }
        public float X { get; set; }
        public string Color { get; set; }
    }
}