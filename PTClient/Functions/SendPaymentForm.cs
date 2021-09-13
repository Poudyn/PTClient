using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PaymentResult>> SendPaymentFormAsync(this TdClient tdClient, TdApi.SendPaymentForm sendPaymentForm)
        {
            TdResult<TdApi.PaymentResult> tdResult = new TdResult<TdApi.PaymentResult>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(sendPaymentForm);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PaymentResult;
            }
            return tdResult;
        }
    }
}