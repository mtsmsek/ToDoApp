using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.Users;
using ToDoApp.Api.Domain.Models.Users;
using ToDoApp.Common.Application.RequestModels.Users;

namespace ToDoApp.Api.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(request.Password != request.PasswordConfirm)
            {

                return Guid.Empty;
            }

            //TODO email kontrol
            var userToAdd = _mapper.Map<User>(request);
            await _userRepository.AddAsync(userToAdd);


            return userToAdd.Id;
        }
    }
}
