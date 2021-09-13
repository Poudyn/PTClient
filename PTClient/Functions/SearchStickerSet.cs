using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.StickerSet>> SearchStickerSetAsync(this TdClient tdClient, TdApi.SearchStickerSet searchStickerSet)
        {
            TdResult<TdApi.StickerSet> tdResult = new TdResult<TdApi.StickerSet>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(searchStickerSet);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.StickerSet;
            }
            return tdResult;
        }
    }
}