using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.StickerSet>> CreateNewStickerSetAsync(this TdClient tdClient, TdApi.CreateNewStickerSet createNewStickerSet)
        {
            TdResult<TdApi.StickerSet> tdResult = new TdResult<TdApi.StickerSet>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(createNewStickerSet);
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