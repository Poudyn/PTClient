using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Backgrounds>> GetBackgroundsAsync(this TdClient tdClient, TdApi.GetBackgrounds getBackgrounds)
        {
            TdResult<TdApi.Backgrounds> tdResult = new TdResult<TdApi.Backgrounds>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getBackgrounds);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Backgrounds;
            }
            return tdResult;
        }
    }
}