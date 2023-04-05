using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class //veritabanina yapilacak tum sorgular buraya eklenecek (dbden data alma ile ilgili islemleri gerceklestirir.)
    {
        Task<T> GetByIdAsync(int id);

        // productRepository.where(x=>x.id>5).orderby.ToListAsync();
        // alt kismi neden list yapmadik? | bunun nedeni yukaridaki kodu su sekilde calistirirdi -> orderby'dan onceki kisma kadar giderdi sonrasinda ise gelen sonucu memorye alir sonrasinda orderby islemi yapardi, fakat IQueryable seklinde donerse orderby kismini da databasede islem gerceklestirir
        IQueryable<T> Where(Expression<Func<T,bool>> expression);

        IQueryable<T> GetAll();

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity); //efcore update ve delete icin async metotlari yoktur gerek de yoktur

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entites);
    }
}
