using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Domain.Models.Users;
using ToDoApp.Common.Application.RequestModels.Users;

namespace ToDoApp.Api.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
