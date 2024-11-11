using AgroSmart.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSmart.Infraestructure.Persistence.EntityConfigurations
{
    public class TasksConfig : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable("Tarea/evento");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired();

            builder.Property(t => t.Description)
                .IsRequired();

            builder.Property(t => t.UserId)
                .IsRequired();
        }
    }
}
