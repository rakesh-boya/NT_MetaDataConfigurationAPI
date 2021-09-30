using MetaDataConfigurationAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadConfigurationController : ControllerBase
    {
        private readonly IReadRepository _readRepository;
        public ReadConfigurationController(IReadRepository readRepository) =>
            _readRepository = readRepository;

        [HttpGet]
        public async Task<IActionResult> GetConfigurationDataFromAllSources()
        {
            var result = await _readRepository.GetAllConfigurationDataAsync();
            return Ok(result);
        }        
    }
}
