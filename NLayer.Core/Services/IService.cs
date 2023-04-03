using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class //GenericRepodan alinana datayi isler ve controllerlara istedigi datayi hazirlamak icindir. Business kod service icerisinde yazilir. try-catch yazacaksak serviceler icerisinde yazilir. DTO donusumleri gerceklestireceksek yine service siniflarinda bu islem yapilir
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAllAsync();

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entites);

        Task UpdateAsync(T entity);  //veritabanina bu degisiklikler yansitilacagi ve savechangeasync metot kullanilacagi icin asenkrona donusturulur

        Task RemoveAsync(T entity);

        Task RemoveRangeAsync(IEnumerable<T> entites);
    }
}
