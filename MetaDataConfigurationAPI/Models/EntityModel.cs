using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Models
{
    public class EntityModel
    {
        public string EntityName { get; set; }
        [Key]
        [MapTo("FieldName")]
        public string Field { get; set; }
        [MapTo("IsRequired")]
        public bool IsRquired { get; set; }
        public int MaxLength { get; set; }
        [MapTo("FieldSource")]
        public string Source { get; set; }
    }
}
