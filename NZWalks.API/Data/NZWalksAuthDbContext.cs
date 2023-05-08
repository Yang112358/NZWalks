using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "2400fae9-6d98-47ae-ab4e-71c223046376";// Open view -> other window => C# Interactive Guid.NewGuid()
            var writerRoleId = "1633d37e-0364-49f4-838b-7b0ab400e1d3";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }

            };


            builder.Entity<IdentityRole>().HasData(roles);

        }


    }
}

//Add-Migration "Creating Auth Database" -Context "NZWalksAuthDbContext"
//Update-Database -Context "NZWalksAuthDbContext"
