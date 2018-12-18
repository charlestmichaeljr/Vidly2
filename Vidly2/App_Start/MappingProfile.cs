using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer,CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();

            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(c => c.Id, opt => opt.Ignore()); ;
        }
    }
}