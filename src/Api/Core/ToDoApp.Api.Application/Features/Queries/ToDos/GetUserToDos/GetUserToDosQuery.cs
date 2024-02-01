using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common.Application.Queries.ToDos;
using ToDoApp.Common.Pages;

namespace ToDoApp.Api.Application.Features.Queries.ToDos.GetUserToDos
{
    public class GetUserToDosQuery : BasedPageQuery, IRequest<PagedViewModel<GetUserToDosViewModel>>
    {
        public GetUserToDosQuery(Guid userId, int currentPage, int pageSize) : base(currentPage, pageSize)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }
    }
}
