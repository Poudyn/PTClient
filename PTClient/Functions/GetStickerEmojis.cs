using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Emojis>> GetStickerEmojisAsync(this TdClient tdClient, TdApi.GetStickerEmojis getStickerEmojis)
        {
            TdResult<TdApi.Emojis> tdResult = new TdResult<TdApi.Emojis>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getStickerEmojis);
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