using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configuration;
using System.Drawing;
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


            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature() //seed uzerinden yapilabildigi gibi bu kisimdan da halledilebilir (seed best practice'dir)
            {
                Id= 1,
                Color = "kirmizi",
                Height = 100,
                Width = 200,
                ProductId = 1
            },

            new ProductFeature()
            {
                Id = 2,
                Color = "mavi",
                Height = 300,
                Width = 250,
                ProductId = 2
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
