using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.LogStream>> GetLogStreamAsync(this TdClient tdClient, TdApi.GetLogStream getLogStream)
        {
            TdResult<TdApi.LogStream> tdResult = new TdResult<TdApi.LogStream>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getLogStream);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.LogStream;
            }
            return tdResult;
        }
    }
}