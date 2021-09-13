using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.BasicGroup>> GetBasicGroupAsync(this TdClient tdClient, TdApi.GetBasicGroup getBasicGroup)
        {
            TdResult<TdApi.BasicGroup> tdResult = new TdResult<TdApi.BasicGroup>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getBasicGroup);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.BasicGroup;
            }
            return tdResult;
        }
    }
}