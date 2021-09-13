using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PushReceiverId>> RegisterDeviceAsync(this TdClient tdClient, TdApi.RegisterDevice registerDevice)
        {
            TdResult<TdApi.PushReceiverId> tdResult = new TdResult<TdApi.PushReceiverId>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(registerDevice);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PushReceiverId;
            }
            return tdResult;
        }
    }
}