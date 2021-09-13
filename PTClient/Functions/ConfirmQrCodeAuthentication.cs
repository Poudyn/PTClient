using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Session>> ConfirmQrCodeAuthenticationAsync(this TdClient tdClient, TdApi.ConfirmQrCodeAuthentication confirmQrCodeAuthentication)
        {
            TdResult<TdApi.Session> tdResult = new TdResult<TdApi.Session>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(confirmQrCodeAuthentication);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Session;
            }
            return tdResult;
        }
    }
}