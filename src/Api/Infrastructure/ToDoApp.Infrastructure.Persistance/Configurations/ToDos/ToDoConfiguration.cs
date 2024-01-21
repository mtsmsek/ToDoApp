using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Domain.Models.ToDos;
using ToDoApp.Infrastructure.Persistance.Configurations.Commons;

namespace ToDoApp.Infrastructure.Persistance.Configurations.ToDos
{
    public class ToDoConfiguration : BaseEntityConfiguration<ToDo>
    {
        public override void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.Property(x => x.CreatedById).IsRequired();
            builder.Property(x => x.Subject).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.DeadLine);
            builder.Property(x => x.IsPinned);
            builder.Property(x => x.Color);


            builder.HasOne(x => x.CreatedBy)
                    .WithMany(x => x.ToDos)
                    .HasForeignKey(x => x.CreatedById);
        }
    }
}
