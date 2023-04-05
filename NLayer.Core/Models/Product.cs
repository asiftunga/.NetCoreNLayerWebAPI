using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; } //foreign key (asagidaki ile olmus oluyor) | EF core CategoryId kullanimini otomatik olarak algilar, best practices

        public Category Category { get; set; }//productin bir tane kategorisi olabilir

        /*
         simdi diyelim ki CategoryId yerine Category_id yazdim bu durumda EF core bunu algilayamazdi ve alttaki prop icin su attribute'i gostermem gerekirdi
        
        [ForeignKey("Category_id")]
        public Category Category { get; set; }
        

        category ve product arasinda bire cok iliski kuruldu
         */

        public ProductFeature? ProductFeature { get; set; } //1-1 iliski | ? isareti nullable degiskenlerin degerini kontrol etmek icin kullanilir ve bir değişkenin null olabilen (nullable) bir veri tipi olduğunu belirtir, bu degisken degeri null olabilen bir degiskendir, eger deger null ise bu operator debugging esnasinda programin hata vermesini engeller

        //"??", null koalesans operatörü olarak adlandırılan bir operatördür. Bu operatör, bir değişkenin değerinin null olup olmadığını kontrol eder ve null ise yerine belirlenen varsayılan değeri atar.




    }
}
