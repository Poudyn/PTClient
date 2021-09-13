using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PassportElements>> GetAllPassportElementsAsync(this TdClient tdClient, TdApi.GetAllPassportElements getAllPassportElements)
        {
            TdResult<TdApi.PassportElements> tdResult = new TdResult<TdApi.PassportElements>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getAllPassportElements);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PassportElements;
            }
            return tdResult;
        }
    }
}