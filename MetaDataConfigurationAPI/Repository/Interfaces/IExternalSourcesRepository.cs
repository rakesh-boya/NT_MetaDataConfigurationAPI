using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Repository.Interfaces
{
    public interface IExternalSourcesRepository
    {
        Task<string> RetrieveDataFromExternalSourcesAsync(string Entity);
    }
}
