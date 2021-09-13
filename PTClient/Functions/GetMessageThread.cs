using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.MessageThreadInfo>> GetMessageThreadAsync(this TdClient tdClient, TdApi.GetMessageThread getMessageThread)
        {
            TdResult<TdApi.MessageThreadInfo> tdResult = new TdResult<TdApi.MessageThreadInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getMessageThread);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.MessageThreadInfo;
            }
            return tdResult;
        }
    }
}