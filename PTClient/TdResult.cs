namespace PTClient
{
    public class TdResult<TResult>
    {
        public bool Successful { internal set; get; }
        public TResult Result { internal set; get; }
        public Telegram.Td.Api.Error Error { internal set; get; }
    }
}
