using MemoryPack;

namespace Shared.Packets
{
    [MemoryPackable]
    public partial class BasePacket
    {
        public string Username { get; set; }
    }

    [MemoryPackable]
    public partial class BaseResponsePacket
    {
        public ErrorCode ErrorCode { get; set; } = ErrorCode.Success;
    }
}