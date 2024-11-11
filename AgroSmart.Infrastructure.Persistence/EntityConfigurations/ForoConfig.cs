using AgroSmart.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Infraestructure.Persistence.EntityConfigurations
{
    public class ForoConfig : IEntityTypeConfiguration<Foro>
    {
        public void Configure(EntityTypeBuilder<Foro> builder)
        {
            builder.ToTable("Foro");

            builder.HasKey(x => x.Id);

            builder.HasMany<Comments>(c=>c.Comments)
                .WithOne(f=>f.Foro)
                .HasForeignKey(f=>f.ForoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();
        }
    }
}
