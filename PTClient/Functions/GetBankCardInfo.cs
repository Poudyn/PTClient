using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.BankCardInfo>> GetBankCardInfoAsync(this TdClient tdClient, TdApi.GetBankCardInfo getBankCardInfo)
        {
            TdResult<TdApi.BankCardInfo> tdResult = new TdResult<TdApi.BankCardInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getBankCardInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.BankCardInfo;
            }
            return tdResult;
        }
    }
}