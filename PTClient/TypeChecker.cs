using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient
{
    internal static class TypeChecker
    {
        internal static bool IsUpdate(this Type updateType)
        {
            return updateType == typeof(Telegram.Td.Api.Update);
        }
        internal static bool IsBaseObject(this Type updateType)
        {
            return updateType == typeof(Telegram.Td.Api.BaseObject);
        }
    }
}
