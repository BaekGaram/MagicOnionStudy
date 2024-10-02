namespace Shared.Packets
{
    public partial class ReqJoinPacket
    {
        public string UserName { get; set; }
    }

    public partial class ResJoinPacket
    {
        public int ErrorCode { get; set; }
    }
}