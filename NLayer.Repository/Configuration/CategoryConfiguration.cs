using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NLayer.Repository.Configuration
{

    //alttaki metot sayesinde entityler icindeki configurationlari yapabiliriz. Ornek olarak ben yazdigim kodda best practicelere uydum bu nedenle efcore benim id mi anladi, fakat anlamamis olsaydi asagidaki sekilde id nin key oldugunu belirtebilirdim veya diger her turlu ayari burada yapabilirdim
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            //builder.Property(x => x.Id).UseIdentityColumn(1,5); id degeri 4er 4 er artar
            builder.Property(x => x.Id).IsRequired().HasMaxLength(50);//null olamaz ve limit 50
            builder.ToTable("Categories");//tablo ismini degistirmek
        }
    }
}
