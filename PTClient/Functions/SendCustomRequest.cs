using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.CustomRequestResult>> SendCustomRequestAsync(this TdClient tdClient, TdApi.SendCustomRequest sendCustomRequest)
        {
            TdResult<TdApi.CustomRequestResult> tdResult = new TdResult<TdApi.CustomRequestResult>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(sendCustomRequest);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.CustomRequestResult;
            }
            return tdResult;
        }
    }
}