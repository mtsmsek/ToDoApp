using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.WebApi.Controllers.Commons;
using ToDoApp.Common.Application.RequestModels.Users;

namespace ToDoApp.Api.WebApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var result = await Mediator!.Send(createUserCommand);
            return Ok(result);
        }
    }
}
