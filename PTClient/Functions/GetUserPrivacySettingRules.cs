using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.UserPrivacySettingRules>> GetUserPrivacySettingRulesAsync(this TdClient tdClient, TdApi.GetUserPrivacySettingRules getUserPrivacySettingRules)
        {
            TdResult<TdApi.UserPrivacySettingRules> tdResult = new TdResult<TdApi.UserPrivacySettingRules>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getUserPrivacySettingRules);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.UserPrivacySettingRules;
            }
            return tdResult;
        }
    }
}