using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PhoneNumberInfo>> GetPhoneNumberInfoAsync(this TdClient tdClient, TdApi.GetPhoneNumberInfo getPhoneNumberInfo)
        {
            TdResult<TdApi.PhoneNumberInfo> tdResult = new TdResult<TdApi.PhoneNumberInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getPhoneNumberInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PhoneNumberInfo;
            }
            return tdResult;
        }
    }
}