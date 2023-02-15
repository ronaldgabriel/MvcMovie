using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MinimalApiSample.DataDb
{
    public class DataBaseWithIdentity : IdentityUserContext<IdentityUser>
    {
        public DataBaseWithIdentity(DbContextOptions<DataBaseWithIdentity> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
