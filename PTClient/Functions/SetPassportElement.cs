using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PassportElement>> SetPassportElementAsync(this TdClient tdClient, TdApi.SetPassportElement setPassportElement)
        {
            TdResult<TdApi.PassportElement> tdResult = new TdResult<TdApi.PassportElement>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(setPassportElement);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PassportElement;
            }
            return tdResult;
        }
    }
}