using MemoryPack;

namespace Shared.Packets
{
    [MemoryPackable]
    public partial class ReqJoinPacket : BasePacket
    {
    }

    [MemoryPackable]
    public partial class ResJoinPacket : BaseResponsePacket
    {
    }
}