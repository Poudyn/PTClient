using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ImportedContacts>> ChangeImportedContactsAsync(this TdClient tdClient, TdApi.ChangeImportedContacts changeImportedContacts)
        {
            TdResult<TdApi.ImportedContacts> tdResult = new TdResult<TdApi.ImportedContacts>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(changeImportedContacts);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ImportedContacts;
            }
            return tdResult;
        }
    }
}