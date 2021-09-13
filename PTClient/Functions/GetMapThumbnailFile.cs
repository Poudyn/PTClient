using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.File>> GetMapThumbnailFileAsync(this TdClient tdClient, TdApi.GetMapThumbnailFile getMapThumbnailFile)
        {
            TdResult<TdApi.File> tdResult = new TdResult<TdApi.File>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getMapThumbnailFile);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.File;
            }
            return tdResult;
        }
    }
}