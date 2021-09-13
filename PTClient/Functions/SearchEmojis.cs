using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Emojis>> SearchEmojisAsync(this TdClient tdClient, TdApi.SearchEmojis searchEmojis)
        {
            TdResult<TdApi.Emojis> tdResult = new TdResult<TdApi.Emojis>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(searchEmojis);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Emojis;
            }
            return tdResult;
        }
    }
}