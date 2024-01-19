using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Domain.Models.Commons;
using ToDoApp.Api.Domain.Models.ToDos;
using ToDoApp.Api.Domain.Models.Users;
using ToDoApp.Common.Constants;

namespace ToDoApp.Infrastructure.Persistance.Context
{
    public class ToDoAppDbContext : DbContext
    {
        public const string DefaultSchema = "dbo";
        /// <summary>
        /// For design time (for migrations)
        /// </summary>
        public ToDoAppDbContext()
        {
            
        }
        public ToDoAppDbContext(DbContextOptions options) :base(options) 
        {
                
        }
        #region Users
        public DbSet<User> Users { get; set; }
        #endregion
        #region ToDos
        public DbSet<ToDo> ToDos { get; set; }
        #endregion
        /// <summary>
        /// For design time (for migrations)
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var connectionString = ToDoAppConstants.PersistanceConstants.DefaultConnectionString;
                optionsBuilder.UseSqlServer(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries()
                                .Where(i => i.State == EntityState.Added)
                                .Select(i => (BaseEntity)i.Entity);
            SetCreatedDatesOfEntities(addedEntities);
        }

        public void SetCreatedDatesOfEntities(IEnumerable<BaseEntity> entities)
        {
            foreach(var entity in entities)
                entity.CreatedDate = DateTime.Now;
        }

    }
}
