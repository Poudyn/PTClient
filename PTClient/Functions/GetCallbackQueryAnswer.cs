using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.CallbackQueryAnswer>> GetCallbackQueryAnswerAsync(this TdClient tdClient, TdApi.GetCallbackQueryAnswer getCallbackQueryAnswer)
        {
            TdResult<TdApi.CallbackQueryAnswer> tdResult = new TdResult<TdApi.CallbackQueryAnswer>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getCallbackQueryAnswer);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.CallbackQueryAnswer;
            }
            return tdResult;
        }
    }
}