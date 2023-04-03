using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    CategoryId=1,
                    Name = "kalem1",
                    Price = 1000,
                    Stock = 20,
                    CreatedDate = DateTime.Now //intercepter yazilabilir (yazilacak)
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "kitap",
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now //intercepter yazilabilir (yazilacak)
                }
            );
        }
    }
}
