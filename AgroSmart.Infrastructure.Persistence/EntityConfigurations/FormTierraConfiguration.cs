using AgroSmart.Core.Domain.Entities;
using AgroSmart.Infraestructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSmart.Infraestructure.Persistence.EntityConfigurations
{
    public class FormTierraConfiguration : IEntityTypeConfiguration<FormTierra>
    {
        public void Configure(EntityTypeBuilder<FormTierra> builder)
        {
            builder.ToTable("FormTierra");

            // Definir la clave primaria
            builder.HasKey(t => t.Id);

            // Configuración de las propiedades
            builder.Property(t => t.TipoDeSuelo)
                .IsRequired() // Obligatorio
                .HasMaxLength(100); // Longitud máxima de 100 caracteres

            builder.Property(t => t.HumedadTerreno)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Drenaje)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.LuzSolar)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.TipoDeRiego)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.TipoDeFertilizacion)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.ProblemasDePlagas)
                .IsRequired();

            builder.Property(t => t.TamanoTerreno)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.UsuarioId)
                .IsRequired(); // UsuarioId es obligatorio

            // Configurar columnas comunes heredadas de BaseEntity
            builder.Property(t => t.Created)
                .IsRequired();

            builder.Property(t => t.LastModified)
                .IsRequired(false);

            // Configurar la relación con ApplicationUser (opcional)
            builder.HasOne<ApplicationUser>()
                .WithMany() // Si ApplicationUser tiene una colección de FormTierra
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
