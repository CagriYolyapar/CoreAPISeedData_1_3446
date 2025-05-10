using CoreAPISeedData_1.Models.CustomTools;
using CoreAPISeedData_1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreAPISeedData_1.Models.ContextClasses
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> opt):base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DataSeedStructure.KategoriEkle(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
