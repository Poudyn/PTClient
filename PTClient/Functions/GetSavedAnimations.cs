using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Animations>> GetSavedAnimationsAsync(this TdClient tdClient, TdApi.GetSavedAnimations getSavedAnimations)
        {
            TdResult<TdApi.Animations> tdResult = new TdResult<TdApi.Animations>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getSavedAnimations);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Animations;
            }
            return tdResult;
        }
    }
}