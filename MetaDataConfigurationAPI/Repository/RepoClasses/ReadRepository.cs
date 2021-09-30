using AutoMapper;
using MetaDataConfigurationAPI.DataBase;
using MetaDataConfigurationAPI.Models;
using MetaDataConfigurationAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Repository.RepoClasses
{
    public class ReadRepository : IReadRepository
    {
        private readonly IExternalSourcesRepository _externalSourcesRepository;
        private readonly EntitiesDbContext _entitiesDbContext;
        private readonly IMapper _mapper;

        public ReadRepository(IExternalSourcesRepository externalSourcesRepository,
            EntitiesDbContext entitiesDbContext,IMapper mapper)
        {
            _externalSourcesRepository = externalSourcesRepository;
            _entitiesDbContext = entitiesDbContext;
            _mapper = mapper;
        }
        
        public async Task<string> GetAllConfigurationDataAsync()
        {
            string defaultSrcResult = await _externalSourcesRepository.RetrieveDataFromExternalSourcesAsync("DefaultFields/Product");
            string customSrcResult = await _externalSourcesRepository.RetrieveDataFromExternalSourcesAsync("CustomFields/Product");
                        
            JObject defaultSrcRes = JObject.Parse(defaultSrcResult);
            JObject customSrcRes = JObject.Parse(customSrcResult);

            defaultSrcRes.Merge(customSrcRes, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            });
            var databaseresult = await TestGetConfigurationDataBaseAsync();

            JArray combinedData = JArray.Parse(databaseresult);
            defaultSrcRes.Merge(combinedData, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            });
            return defaultSrcRes.ToString();
        }

        private async Task<string> TestGetConfigurationDataBaseAsync()
        {
            var entities = await _entitiesDbContext.Entities.ToListAsync();
            var result = _mapper.Map<List<OutputDto>>(entities);
            var option = new JsonSerializerOptions() { WriteIndented = true };
            string databaseResult = JsonSerializer.Serialize<List<OutputDto>>(result, option);
            return databaseResult;
        }

    }
}
