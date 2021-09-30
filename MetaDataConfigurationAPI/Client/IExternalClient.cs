using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Client
{
    public interface IExternalClient
    {
        Task<string> CallExternalAPIAsync(string Entity);
    }
}
