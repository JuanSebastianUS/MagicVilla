﻿using AutoMapper;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using System.Runtime;

namespace MagicVilla_API
{
    public class MappingConfig : Profile 

    {
        public MappingConfig()
        {
                CreateMap<Villa, VillaDto>();
                CreateMap<VillaDto, Villa>();

            CreateMap<Villa, VillaCreateDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();

            CreateMap<NumeroVilla, NumeroVillaDto>().ReverseMap();
            CreateMap<NumeroVilla, NumeroVillaCreateDto>().ReverseMap();
            CreateMap<NumeroVilla, NumeroVillaUpdateDto>().ReverseMap();

        }
    }
}