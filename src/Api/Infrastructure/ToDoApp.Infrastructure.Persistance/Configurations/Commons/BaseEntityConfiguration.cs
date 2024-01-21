using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Domain.Models.Commons;

namespace ToDoApp.Infrastructure.Persistance.Configurations.Commons
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.CreatedDate).IsRequired();
           builder.Property(x => x.UpdatedDate);
        }
    }
}
