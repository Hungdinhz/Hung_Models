using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hung_Models.Models
{
    public class pdhDbContextFactory : IDesignTimeDbContextFactory<pdhDbContext>
    {
        public pdhDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<pdhDbContext>();
            optionsBuilder.UseNpgsql(
                "Host=ep-snowy-boat-a1ag0qbo-pooler.ap-southeast-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_m6g7EJUFplLa;SSL Mode=Require;Trust Server Certificate=true"
            );

            return new pdhDbContext(optionsBuilder.Options);
        }
    }
}
