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
    public class CommentsConfig : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.ToTable("Comentarios");

            builder.HasKey(e=>e.Id);

            builder.Property(e => e.Content)
                .IsRequired();
        }
    }
}
