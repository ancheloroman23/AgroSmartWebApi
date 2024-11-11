using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace AgroSmart.Infraestructure.Identity.Context
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-36MF8L1\\SQLEXPRESS01;Database=AgroSmart;Trusted_Connection=True;");
            /*optionsBuilder.UseSqlServer("Server=CM2022\\SQLSERVER;Database=AgroSmart;Trusted_Connection=True;");*/

            return new IdentityContext(optionsBuilder.Options);
        }
    }

}
