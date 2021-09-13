using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PaymentForm>> GetPaymentFormAsync(this TdClient tdClient, TdApi.GetPaymentForm getPaymentForm)
        {
            TdResult<TdApi.PaymentForm> tdResult = new TdResult<TdApi.PaymentForm>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getPaymentForm);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PaymentForm;
            }
            return tdResult;
        }
    }
}