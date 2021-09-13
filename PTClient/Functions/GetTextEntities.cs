using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.TextEntities>> GetTextEntitiesAsync(this TdClient tdClient, TdApi.GetTextEntities getTextEntities)
        {
            TdResult<TdApi.TextEntities> tdResult = new TdResult<TdApi.TextEntities>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getTextEntities);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.TextEntities;
            }
            return tdResult;
        }
    }
}