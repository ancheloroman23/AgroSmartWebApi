using AgroSmart.Core.Domain.Commons;
using AgroSmart.Core.Domain.Entities;
using AgroSmart.Infraestructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Tasks = AgroSmart.Core.Domain.Entities.Tasks;

namespace AgroSmart.Infraestructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<FormTierra> FormTierras { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Foro> Foros { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Aplicar la configuración de la entidades
            modelBuilder.ApplyConfiguration(new FormTierraConfiguration());
            //modelBuilder.ApplyConfiguration(new TopicConfiguration());
            //modelBuilder.ApplyConfiguration(new PostConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }

}

