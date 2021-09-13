using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PaymentReceipt>> GetPaymentReceiptAsync(this TdClient tdClient, TdApi.GetPaymentReceipt getPaymentReceipt)
        {
            TdResult<TdApi.PaymentReceipt> tdResult = new TdResult<TdApi.PaymentReceipt>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getPaymentReceipt);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PaymentReceipt;
            }
            return tdResult;
        }
    }
}