﻿using AutoMapper;
using Entity.Dtos;
using Entity.Model;

namespace NowaDaysWebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyDtosForinsertion, Companys>();
            CreateMap<CompanyDtosForUpdate, Companys>().ReverseMap();
            CreateMap<ProjectsDtosForinsertion, Projects>();
            CreateMap<ProjectsDtosForUpdate, Projects>().ReverseMap();
            

        }


    }
}
