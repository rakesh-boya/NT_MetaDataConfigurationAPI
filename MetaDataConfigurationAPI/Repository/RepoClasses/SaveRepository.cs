using AutoMapper;
using MetaDataConfigurationAPI.DataBase;
using MetaDataConfigurationAPI.Models;
using MetaDataConfigurationAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Repository.RepoClasses
{
    public class SaveRepository : ISaveRepository
    {
        private readonly EntitiesDbContext _entitiesDbContext;
        private readonly IMapper _mapper;

        public SaveRepository(EntitiesDbContext entitiesDbContext, IMapper mapper)
        {
            _entitiesDbContext = entitiesDbContext;
            _mapper = mapper;
        }
        public async Task<string> SaveConfigurationDataAsync(SaveRequestDto model)
        {
            var entity = _mapper.Map<Entities>(model);
            var existingEntity = await _entitiesDbContext.Entities.AsNoTracking()
                .FirstOrDefaultAsync(x => x.FieldName == model.Fields.Field);
            if (existingEntity != null)
            {
                _entitiesDbContext.Entities.Update(entity);
            }
            else { _entitiesDbContext.Entities.Add(entity); }
            await _entitiesDbContext.SaveChangesAsync();
            return $"Data updated for {model.EntityName} - {model.Fields.Field}";
        }
    }
}
