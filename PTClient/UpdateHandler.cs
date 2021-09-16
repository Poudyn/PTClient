using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Td;
using Telegram.Td.Api;

namespace PTClient
{
    internal class UpdateHandler : ClientResultHandler
    {
        void ClientResultHandler.OnResult(BaseObject baseObject)
        {
            List<IFilter> filters = Filtering.GetFilters(baseObject);
            if (filters.Any())
            {
                filters.RemoveUselessFilters();
                foreach (var i in filters)
                {
                    if (i is ITransportToken transportToken)
                    {
                        transportToken.Transport();
                    }
                    else if (i is ITransportUpdate transportUpdate)
                    {
                        transportUpdate.Transport(baseObject);
                    }
                }
            }
        }
    }
}
