using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Models
{
    public class SaveRequestDto
    {
        [JsonProperty("EntityName")]
        public string EntityName { get; set; }
        [JsonProperty("Fields")]
        public FieldData Fields { get; set; }
        public class FieldData
        {
            [JsonProperty("Field")]
            public string Field { get; set; }
            [JsonProperty("IsRquired")]
            public bool IsRquired { get; set; }
            [JsonProperty("MaxLength")]
            public int MaxLength { get; set; }
            [JsonProperty("Source")]
            public string Source { get; set; }
        }
    }
}
