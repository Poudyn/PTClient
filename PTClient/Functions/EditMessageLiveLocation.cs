using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Message>> EditMessageLiveLocationAsync(this TdClient tdClient, TdApi.EditMessageLiveLocation editMessageLiveLocation)
        {
            TdResult<TdApi.Message> tdResult = new TdResult<TdApi.Message>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(editMessageLiveLocation);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Message;
            }
            return tdResult;
        }
    }
}