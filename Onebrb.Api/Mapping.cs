using AutoMapper;
using Onebrb.Core.Entities;
using Onebrb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Api
{
    public class Mapping : AutoMapper.Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));

            CreateMap<Category, CategoryModel>();

            CreateMap<ApplicationUser, ProfileModel>();
        }
    }
}
