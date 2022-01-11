using AutoMapper;
using Onboarding.Domain.DTOs;
using Onboarding.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // user mappings
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<User, UserRegistrationDto>().ReverseMap();
            CreateMap<User, UserUpdateProfileDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
