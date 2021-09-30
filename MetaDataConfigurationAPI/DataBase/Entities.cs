using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.DataBase
{
    public class Entities
    {
        public string EntityName { get; set; }
        [Key]
        [MapTo("Field")]
        public string FieldName { get; set; }
        [MapTo("IsRquired")]
        public string IsRequired { get; set; }
        public int MaxLength { get; set; }
        [MapTo("Source")]
        public string FieldSource { get; set; }
    }
}
