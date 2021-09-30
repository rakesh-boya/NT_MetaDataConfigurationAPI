using MetaDataConfigurationAPI.Client;
using MetaDataConfigurationAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Repository.RepoClasses
{
    public class ExternalSourcesRepository : IExternalSourcesRepository
    {
        private readonly IExternalClient _externalClient;

        public ExternalSourcesRepository(IExternalClient externalClient) => _externalClient = externalClient;

        public async Task<string> RetrieveDataFromExternalSourcesAsync(string Entity)
        {
            return await _externalClient.CallExternalAPIAsync(Entity);            
        }
    }
}
