using Telegram.Td.Api;

namespace PTClient
{
    internal interface ITransportUpdate
    {
        internal void Transport(BaseObject baseObject);
        internal bool OnlyTypeFiltering { get; }
        internal bool IsBase { get; }
        internal bool IsUpdate { get; }
    }
}
