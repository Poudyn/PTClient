using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatPhotos>> GetUserProfilePhotosAsync(this TdClient tdClient, TdApi.GetUserProfilePhotos getUserProfilePhotos)
        {
            TdResult<TdApi.ChatPhotos> tdResult = new TdResult<TdApi.ChatPhotos>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getUserProfilePhotos);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatPhotos;
            }
            return tdResult;
        }
    }
}