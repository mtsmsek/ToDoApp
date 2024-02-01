using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.Application.Features.Queries.ToDos.GetUserToDos;
using ToDoApp.Api.WebApi.Controllers.Commons;
using ToDoApp.Common.Application.RequestModels.ToDos;

namespace ToDoApp.Api.WebApi.Controllers.ToDos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : BaseController
    {
      
            [HttpPost]
            public async Task<IActionResult> CreateToDo(CreateToDoCommand createToDoCommand)
            {
                var result = await Mediator!.Send(createToDoCommand);
                return Ok(result);
            }
            [HttpGet]
            [Route("UserToDos/{userId}")]
            public async Task<IActionResult> GetUserToDos(Guid userId, int currentPage, int pageSize)
            {
                var result = await Mediator!.Send(new GetUserToDosQuery(userId, currentPage, pageSize));
                return Ok(result);
            }
        }
    
}
