using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Features.Queries.ToDos.GetUserToDos;
using ToDoApp.Api.Domain.Models.ToDos;
using ToDoApp.Api.Domain.Models.Users;
using ToDoApp.Common.Application.Queries.ToDos;
using ToDoApp.Common.Application.RequestModels.ToDos;
using ToDoApp.Common.Application.RequestModels.Users;
using ToDoApp.Common.Pages;

namespace ToDoApp.Api.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<User, CreateUserCommand>().ReverseMap();


            CreateMap<ToDo, CreateToDoCommand>().ReverseMap();
            CreateMap<PagedViewModel<ToDo>, PagedViewModel<GetUserToDosViewModel>>().ReverseMap();
            CreateMap<ToDo, GetUserToDosViewModel>().ReverseMap();
        }
    }
}
