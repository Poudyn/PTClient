using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Background>> SetBackgroundAsync(this TdClient tdClient, TdApi.SetBackground setBackground)
        {
            TdResult<TdApi.Background> tdResult = new TdResult<TdApi.Background>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(setBackground);
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