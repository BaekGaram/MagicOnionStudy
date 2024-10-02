namespace Shared.Packets
{
    public partial class BroadCastPacket
    {
        public string Sender { get; set; }
        public string Message { get; set; }
    }

    public partial class JoinNotificationPacket
    {
        public string UserName { get; set; }
    }

    public partial class LeaveNotificationPacket
    {
        public string UserName { get; set; }
    }
}