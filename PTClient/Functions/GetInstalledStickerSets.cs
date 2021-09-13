using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.StickerSets>> GetInstalledStickerSetsAsync(this TdClient tdClient, TdApi.GetInstalledStickerSets getInstalledStickerSets)
        {
            TdResult<TdApi.StickerSets> tdResult = new TdResult<TdApi.StickerSets>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getInstalledStickerSets);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.StickerSets;
            }
            return tdResult;
        }
    }
}