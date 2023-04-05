using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class ProductFeature // BaseEntity vermeye gerek yok cunku bunlar producta bagli, bu nedenle her productin bir productfeature olmak zorunda, productin olusturulma tarihi aslinda productfeaturein olusturulma tarihidir. Bu nedenle gerek yok
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
