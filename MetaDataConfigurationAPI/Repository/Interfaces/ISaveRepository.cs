using MetaDataConfigurationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Repository.Interfaces
{
    public interface ISaveRepository
    {
        Task<String> SaveConfigurationDataAsync(SaveRequestDto model);
    }
}
