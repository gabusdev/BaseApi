using BaseApi.Core.Entities;
using BaseApi.DataEF.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.DataEF
{
    public class CoreDbContext : IdentityDbContext<User>
    {
        public CoreDbContext(DbContextOptions option) : base(option) { }

        //public DbSet<Your_Entitie> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            //builder.ApplyConfiguration(new Your_Entity_Configuration());
        }
    }
}
