using AutoMapper;
using MetaDataConfigurationAPI.DataBase;
using MetaDataConfigurationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Helpers
{
    public class MappingHelper : Profile
    {
        public MappingHelper()
        {
            CreateMap<EntityModel, Entities>().ReverseMap();

            CreateMap<Entities, OutputDto>()
                .ForPath(dest => dest.Fields.Field, act => act.MapFrom(src => src.FieldName))
                .ForPath(dest => dest.Fields.IsRquired, act => act.MapFrom(src => src.IsRequired))
                .ForPath(dest => dest.Fields.MaxLength, act => act.MapFrom(src => src.MaxLength))
                .ForPath(dest => dest.Fields.Source, act => act.MapFrom(src => src.FieldSource))
                .ForPath(dest => dest.EntityName, act => act.MapFrom(src => src.EntityName));

            CreateMap<SaveRequestDto, Entities>()
                .ForPath(dest => dest.EntityName, act => act.MapFrom(src => src.EntityName))
                .ForPath(dest => dest.FieldName, act => act.MapFrom(src => src.Fields.Field))
                .ForPath(dest => dest.IsRequired, act => act.MapFrom(src => src.Fields.IsRquired))
                .ForPath(dest => dest.FieldSource, act => act.MapFrom(src => src.Fields.Source))
                .ForPath(dest => dest.MaxLength, act => act.MapFrom(src => src.Fields.MaxLength));
        }
    }
}
