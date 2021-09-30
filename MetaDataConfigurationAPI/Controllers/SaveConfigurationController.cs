using MetaDataConfigurationAPI.Models;
using MetaDataConfigurationAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveConfigurationController : ControllerBase
    {
        private readonly ISaveRepository _saveRepository;
        public SaveConfigurationController(ISaveRepository saveRepository)
        {
            _saveRepository = saveRepository;
        }
        [HttpPost]
        public async Task<IActionResult> SaveConfigurationData(SaveRequestDto model)
        {
            if (model.EntityName != null || model.Fields!=null)
            {
                var result = await _saveRepository.SaveConfigurationDataAsync(model);
                return Ok(result);
            }
            else { return BadRequest(); }
        }
    }
}
