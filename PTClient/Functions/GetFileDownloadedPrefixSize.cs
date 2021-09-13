using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Count>> GetFileDownloadedPrefixSizeAsync(this TdClient tdClient, TdApi.GetFileDownloadedPrefixSize getFileDownloadedPrefixSize)
        {
            TdResult<TdApi.Count> tdResult = new TdResult<TdApi.Count>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getFileDownloadedPrefixSize);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Count;
            }
            return tdResult;
        }
    }
}