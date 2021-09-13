using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Stickers>> AddRecentStickerAsync(this TdClient tdClient, TdApi.AddRecentSticker addRecentSticker)
        {
            TdResult<TdApi.Stickers> tdResult = new TdResult<TdApi.Stickers>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(addRecentSticker);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Stickers;
            }
            return tdResult;
        }
    }
}