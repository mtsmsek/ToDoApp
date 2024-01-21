using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common.Application.RequestModels.Users
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public CreateUserCommand()
        {

        }
        public CreateUserCommand(string firstName, string lastName, string email,
                                        string password, string passwordConfirm)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }
    }
}
