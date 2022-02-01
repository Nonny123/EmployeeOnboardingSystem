using AutoMapper;
using Google.Apis.Calendar.v3.Data;
using Onboarding.Domain.DTOs;
using Onboarding.Domain.Entities;
using OnBoarding.Infrastructure.Interfaces;
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
            CreateMap<Event, GoogleCalendarEventInviteDto>()
                .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ReverseMap();

            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<User, UserRegistrationDto>().ReverseMap();
            CreateMap<User, UserUpdateProfileDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();


            CreateMap<Employee, EmployeeResponseDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.User.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.User.Gender))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.User.DateOfBirth))
                .ForMember(dest => dest.EmployeeStartDate, opt => opt.MapFrom(src => src.EmployeeStartDate.ToShortDateString()))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.User.Avatar));
            //.ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary.ToString("C", CultureInfo.CreateSpecificCulture("HA-LATN-NG"))));


            CreateMap<User, UserResponseDto>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
           .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
           .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
           .ForMember(dest => dest.PhoneNumber2, opt => opt.MapFrom(src => src.PhoneNumber2))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.ResidentialAddress, opt => opt.MapFrom(src => src.ResidentialAddress))
           .ForMember(dest => dest.CityOfResidence, opt => opt.MapFrom(src => src.CityOfResidence))
           .ForMember(dest => dest.StateofResidence, opt => opt.MapFrom(src => src.StateofResidence))
           .ForMember(dest => dest.StateofOrigin, opt => opt.MapFrom(src => src.StateofOrigin))
           .ForMember(dest => dest.CountryOfOrigin, opt => opt.MapFrom(src => src.CountryOfOrigin))
           .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar));
        }
    }
}
