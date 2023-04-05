using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } //bir kategorinin birden fazla producti olabilir 1-N iliski | bu prop turune navigation prop ismi verilir


    }
}
