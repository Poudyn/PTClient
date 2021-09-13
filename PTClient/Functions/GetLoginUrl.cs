using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.HttpUrl>> GetLoginUrlAsync(this TdClient tdClient, TdApi.GetLoginUrl getLoginUrl)
        {
            TdResult<TdApi.HttpUrl> tdResult = new TdResult<TdApi.HttpUrl>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getLoginUrl);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.HttpUrl;
            }
            return tdResult;
        }
    }
}