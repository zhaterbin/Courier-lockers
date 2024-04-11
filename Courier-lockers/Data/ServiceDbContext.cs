using Courier_lockers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courier_lockers.Data
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
         : base(options)
        {
            try
            {
                this.Database.SetCommandTimeout(300);


            }catch (Exception ex) { }
        }
        public DbSet<edpmain> edpmains { get; set; }
        //表和视图
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<edpmain>().HasKey(x => x.Id);
        }
    }
}
