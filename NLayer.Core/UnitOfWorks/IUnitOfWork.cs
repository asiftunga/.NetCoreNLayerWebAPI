using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.UnitOfWorks
{
    public interface IUnitOfWork //unit of workun avantaji -> olmadan controller database contextine direkt olarak erisim sagliyordu fakat uow sayesinde controller ve db context arasinda bir abstraction yapilmis oldu. UOW sayesinde farkli repositorylerde yapilan degisiklikleri savechange cagrilana kadar efcore bunlari memoryde tutar. Fakat her repository isleminden sonra savechange metot cagrilmamali bunun nedeni ornegin bir repo db islemi basarili olabilir fakat digeri olmayabilir bu da db de tutarsiz datalara neden olabilir. iste unit of work burada devreye girer. IUnitOfWork uzerinden savechanges cagrildigi zaman butun repolardaki yapilan islemler basarili ise bunu db ye yansit fakat biri basarisiz ise digerleri rollback yapilir ve geri alinir. iste bu savechangesin her yerden kontrol edilmesini ve cagrilmasini engellemek icin ayri bir katmana tasinir ve ayri bir interfacemiz olur 
    {
        Task CommitAsync();

        void Commit();

        //bunlari implement edince dbcontextin savechange ve savechangeasync metotlarini cagirmis olacagim
    }
}
