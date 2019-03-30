using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

using CM = Service.ContractModels;
using EM = Service.EntityModels;

namespace Service.Api
{
    public static class MapperDefinition
    {
        public static MapperConfiguration GetMapperDefinition()
        {
            return new MapperConfiguration(config =>
            {
                //external -> internal
                config.CreateMap<CM.Vehicle, EM.Vehicle>()
                    .ForMember(t => t.Year, dest => dest.MapFrom<int>(x => x.Year))
                    .ForMember(t => t.Make, dest => dest.MapFrom(x => x.Make))
                    .ForMember(t => t.Vin, dest => dest.MapFrom<string>(x => x.Vin))
                    .ForMember(t => t.ExteriorColor, dest => dest.MapFrom<string>(x => x.ExteriorColor))
                    .ForMember(t => t.InteriorColor, dest => dest.MapFrom<string>(x => x.InteriorColor))
                    .ForMember(t => t.Transmission, dest => dest.MapFrom(x => x.Transmission))
                    .ForMember(t => t.ForwardGears, dest => dest.MapFrom<int>(x => x.ForwardGears))
                    .ForMember(t => t.ChassisNotation, dest => dest.MapFrom<string>(x => x.ChassisNotation))
                    .ForMember(t => t.EngineNotation, dest => dest.MapFrom<string>(x => x.EngineNotation))
                    .ForMember(t => t.Description, dest => dest.MapFrom<string>(x => x.Description));

                config.CreateMap<CM.Hero, EM.Hero>();

                //internal -> external
                config.CreateMap<EM.Vehicle, CM.Vehicle>()
                    .ForMember(t => t.Year, dest => dest.MapFrom<int>(x => x.Year))
                    .ForMember(t => t.Make, dest => dest.MapFrom(x => x.Make))
                    .ForMember(t => t.Vin, dest => dest.MapFrom<string>(x => x.Vin))
                    .ForMember(t => t.ExteriorColor, dest => dest.MapFrom<string>(x => x.ExteriorColor))
                    .ForMember(t => t.InteriorColor, dest => dest.MapFrom<string>(x => x.InteriorColor))
                    .ForMember(t => t.Transmission, dest => dest.MapFrom(x => x.Transmission))
                    .ForMember(t => t.ForwardGears, dest => dest.MapFrom<int>(x => x.ForwardGears))
                    .ForMember(t => t.ChassisNotation, dest => dest.MapFrom<string>(x => x.ChassisNotation))
                    .ForMember(t => t.EngineNotation, dest => dest.MapFrom<string>(x => x.EngineNotation))
                    .ForMember(t => t.Description, dest => dest.MapFrom<string>(x => x.Description));

                config.CreateMap<EM.Hero, CM.Hero>();
            });
        }
    }
}
