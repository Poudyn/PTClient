using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Background>> SearchBackgroundAsync(this TdClient tdClient, TdApi.SearchBackground searchBackground)
        {
            TdResult<TdApi.Background> tdResult = new TdResult<TdApi.Background>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(searchBackground);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Background;
            }
            return tdResult;
        }
    }
}