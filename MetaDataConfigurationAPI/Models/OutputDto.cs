using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Models
{
    public class OutputDto
    {
        public string EntityName { get; set; }
        public FieldData Fields { get; set; }

        public class FieldData
        {
            public string Field { get; set; }
            public bool IsRquired { get; set; }
            public int MaxLength { get; set; }
            public string Source { get; set; }
        }
    }
}