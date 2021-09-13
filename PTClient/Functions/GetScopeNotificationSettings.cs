using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ScopeNotificationSettings>> GetScopeNotificationSettingsAsync(this TdClient tdClient, TdApi.GetScopeNotificationSettings getScopeNotificationSettings)
        {
            TdResult<TdApi.ScopeNotificationSettings> tdResult = new TdResult<TdApi.ScopeNotificationSettings>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getScopeNotificationSettings);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ScopeNotificationSettings;
            }
            return tdResult;
        }
    }
}