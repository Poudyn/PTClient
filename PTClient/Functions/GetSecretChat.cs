using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.SecretChat>> GetSecretChatAsync(this TdClient tdClient, TdApi.GetSecretChat getSecretChat)
        {
            TdResult<TdApi.SecretChat> tdResult = new TdResult<TdApi.SecretChat>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getSecretChat);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.SecretChat;
            }
            return tdResult;
        }
    }
}