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
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Name))
                .ForMember(x => x.OwnerFirstName, y => y.MapFrom(z => z.Owner.FirstName))
                .ForMember(x => x.OwnerLastName, y => y.MapFrom(z => z.Owner.LastName))
                .ReverseMap();

            CreateMap<Category, CategoryModel>()
                .ReverseMap();
        }
    }
}
