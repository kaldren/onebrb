using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Data
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Core.Entities.ApplicationUser, Core.Entities.Profile>()
                .ReverseMap();
            CreateMap<Core.Entities.Product, Core.Models.ProductModel>()
                .ReverseMap();
            // Additional mappings here...
        }
    }
}
