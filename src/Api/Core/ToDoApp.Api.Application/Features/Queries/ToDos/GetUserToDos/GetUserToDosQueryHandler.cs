using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.ToDos;
using ToDoApp.Common.Application.Queries.ToDos;
using ToDoApp.Common.Pages;

namespace ToDoApp.Api.Application.Features.Queries.ToDos.GetUserToDos
{
    public class GetUserToDosQueryHandler : IRequestHandler<GetUserToDosQuery, PagedViewModel<GetUserToDosViewModel>>
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public GetUserToDosQueryHandler(IToDoRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task<PagedViewModel<GetUserToDosViewModel>> Handle(GetUserToDosQuery request, CancellationToken cancellationToken)
        {
            //check request.Id is null or not
            var toDos = await _toDoRepository.GetListAsync(predicate: toDo => toDo.CreatedById == request.UserId,
                                                            currentPage: request.CurrentPage,
                                                            pageSize: request.PageSize);

            var mapped = _mapper.Map<PagedViewModel<GetUserToDosViewModel>>(toDos);

            return mapped;
        }
    }
}
