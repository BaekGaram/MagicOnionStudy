using MemoryPack;

namespace Shared.Packets
{
    [MemoryPackable]
    public partial class ReqSendMessagePacket : BasePacket
    {
        public string Message { get; set; }
    }

    [MemoryPackable]
    public partial class ResSendMessagePacket : BaseResponsePacket
    {
    }
}