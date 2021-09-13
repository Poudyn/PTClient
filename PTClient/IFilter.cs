using Telegram.Td.Api;

namespace PTClient
{
    public interface IFilter
    {
        internal bool IsMatch(BaseObject update);
        internal bool Disposable { set; get; }
    }
}
