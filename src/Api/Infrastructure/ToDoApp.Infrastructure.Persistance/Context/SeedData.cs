using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Domain.Models.ToDos;
using ToDoApp.Api.Domain.Models.Users;
using ToDoApp.Common.Constants;
using ToDoApp.Common.Domains.ToDos;
using ToDoApp.Common.Infrastructure.Encryptors;

namespace ToDoApp.Infrastructure.Persistance.Context
{
    internal class SeedData
    {
       private static List<User> GetUsers()
        {
            var users = new Faker<User>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-365), DateTime.Now))
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.LastName, i => i.Person.LastName)
                .RuleFor(i => i.Email, i => i.Internet.Email())
                .RuleFor(i => i.Password, i => PasswordEncryptor.Encrypt(i.Internet.Password()))
                .Generate(100);

            return users;
        }
        private static List<ToDo> GetToDos(IEnumerable<Guid> userIds)
        {
             var sentenceNumberList = Enumerable.Range(1, 10).ToList();
             var subjectNumberList = Enumerable.Range(1, 3).ToList();
            var toDos = new Faker<ToDo>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-365), DateTime.Now))
                .RuleFor(i => i.CreatedById, i => i.PickRandom(userIds))
                .RuleFor(i => i.Content, i => i.Lorem.Sentences(i.PickRandom(sentenceNumberList)))
                .RuleFor(i => i.Subject, i => i.Lorem.Sentence(i.PickRandom(subjectNumberList)))
                .RuleFor(i => i.IsPinned, i => i.PickRandom(true, false))
                .RuleFor(i => i.Color, i => i.PickRandom(ToDoColor.Red, ToDoColor.Orange, ToDoColor.Blue, ToDoColor.Green))
                .Generate(500);

            return toDos;



        }
        public async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            var context = new ToDoAppDbContext(dbContextBuilder.Options);
            if(context.Users.Any())
            {
                await Task.CompletedTask;
                return;
            }

            var users = GetUsers();
            var userIds = users.Select(i => i.Id);
            
            await context.Users.AddRangeAsync(users);

            var toDos = GetToDos(userIds);

            await context.ToDos.AddRangeAsync(toDos);

            await context.SaveChangesAsync();
        }
    }
}
