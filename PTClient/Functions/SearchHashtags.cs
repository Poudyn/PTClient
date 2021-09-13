using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Hashtags>> SearchHashtagsAsync(this TdClient tdClient, TdApi.SearchHashtags searchHashtags)
        {
            TdResult<TdApi.Hashtags> tdResult = new TdResult<TdApi.Hashtags>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(searchHashtags);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Hashtags;
            }
            return tdResult;
        }
    }
}