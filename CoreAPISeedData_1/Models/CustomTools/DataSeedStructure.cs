using CoreAPISeedData_1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreAPISeedData_1.Models.CustomTools
{
    public static class DataSeedStructure
    {
        public static void KategoriEkle(ModelBuilder modelBuilder)
        {
            Category c = new Category
            {
                Id = 1,
                CategoryName = "Tatlılar",
                Description = "Test verisidir"
            };

            modelBuilder.Entity<Category>().HasData(c);
        }
    }
}
