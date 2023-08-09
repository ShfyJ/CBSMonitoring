using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CBSMonitoring.Models;

namespace CBSMonitoring.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<OrgMonitoring> OrgMonitorings { get; set; }
        public DbSet<ActionPlanToEnsureIC> ActionPlanToEnsureICs { get; set; }
    }
}
