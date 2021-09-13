using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.File>> GetRemoteFileAsync(this TdClient tdClient, TdApi.GetRemoteFile getRemoteFile)
        {
            TdResult<TdApi.File> tdResult = new TdResult<TdApi.File>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getRemoteFile);
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