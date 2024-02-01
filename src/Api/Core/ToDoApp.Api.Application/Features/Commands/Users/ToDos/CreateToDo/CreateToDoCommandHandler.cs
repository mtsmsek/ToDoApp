using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.ToDos;
using ToDoApp.Api.Domain.Models.ToDos;
using ToDoApp.Common.Application.RequestModels.ToDos;

namespace ToDoApp.Api.Application.Features.Commands.Users.ToDos.CreateToDo
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, Guid>
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public CreateToDoCommandHandler(IToDoRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDoToAdd = _mapper.Map<ToDo>(request);

            await _toDoRepository.AddAsync(toDoToAdd);

            return toDoToAdd.Id;
        }
    }
}
