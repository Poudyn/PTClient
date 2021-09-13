using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Message>> SendMessageAsync(this TdClient tdClient, TdApi.SendMessage sendMessage)
        {
            TdResult<TdApi.Message> tdResult = new TdResult<TdApi.Message>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(sendMessage);
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