using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DanialCMS.EndPoints.WebUI.Infrastructures.Identity
{
    public class CMSIdentityDbContext : IdentityDbContext<User>
    {
        public CMSIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

}
