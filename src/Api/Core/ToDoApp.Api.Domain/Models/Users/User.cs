﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Domain.Models.Commons;
using ToDoApp.Api.Domain.Models.ToDos;

namespace ToDoApp.Api.Domain.Models.Users
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }

    }
}
