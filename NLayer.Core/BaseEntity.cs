using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public abstract class BaseEntity //obje olusturulamasin - abstract classlar ortak prop ve metotlarin tanimlandigi yerlerdir, interfacelerde sadece sozlesmeler tanimlanir (version 8 e kadar), ayrica interface ile bir farki c# da classlar birden fazla classtan inheritence olamazlar fakat birden fazla interfaceden olabilirler ayrica abstract classlarin ctorlari diger classlari etkileyebilir
    {
        public int Id { get; set; } //EF core bu id yi gordu mu bunu direkt olarak primary key olarak alir
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDAte {  get; set; } 
    }

}