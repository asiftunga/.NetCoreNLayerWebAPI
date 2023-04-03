using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configuration;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)//DbContextOptions<> startup dosyasindan veritabani yolunu vermemizi saglayacak
        {
            //var p = new Product() { ProductFeature = new ProductFeature() { } }
            //ustteki kismi su durumda yapariz -> sadece varolan veya o an olusturulan productlara productfeature ozellikleri eklenebilir. Burada goruldugu gibi zaten product uzerinden erisilebiliyor
        }

        //her bir entitye karsilik bir dbset
        public DbSet<Category> Categories { get; set; } //tablo ismi Categories (bu kisimdan default olarak alinir)

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //butun configurationlari apply et demek
            //modelBuilder.ApplyConfiguration(new ProductConfiguration)
            //ustteki sekilde de tek tek eklenebilir
            base.OnModelCreating(modelBuilder);
        }
    }
}
