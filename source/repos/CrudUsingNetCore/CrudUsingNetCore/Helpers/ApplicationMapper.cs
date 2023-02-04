using AutoMapper;
using CrudUsingNetCore.Models;
using CrudUsingNetCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingNetCore.Helpers
{
    public class ApplicationMapper :Profile
    {

        public ApplicationMapper()
        {
            //CreateMap<ICustomer, Customer>().ReverseMap();
            CreateMap<DTO.Customer, Models.Customer>().ReverseMap()
                .ForMember(dest=>dest.CustomerName,options=>options.MapFrom(src=>src.Name))
                .ForMember(dest => dest.CustomerCity, options => options.MapFrom(src => src.City));
        }
    }
}
