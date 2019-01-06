using AutoMapper;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.AutoMapper
{
    class AutoMapperProfileMark : Profile
    {
        public AutoMapperProfileMark()
        {
            CreateMap<Gift, GiftDTO>();
            CreateMap<GiftDTO, Gift>();
        }
        //Install-Package AutoMapper
        //Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
    }
}
