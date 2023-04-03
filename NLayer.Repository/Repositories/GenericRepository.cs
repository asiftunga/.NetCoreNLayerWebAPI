using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System.Linq.Expressions;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        private readonly DbSet<T> _dbset; //ctorda deger atanacak ve sonrasinda set edilmemesi icin readonly yapilir

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.AnyAsync(expression);

        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbset.AsNoTracking().AsQueryable(); //asnotracking efcore cekmis oldugu datalari memorye almasin. Bu nedenle uygulama performansi arttirilmistir
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Remove(T entity) //asenkron degil bunun sebebi -> entitynin stateini deleted olarak flag gibi isaretliyoruz ve sonrasinda savechanges ile db ye gonderiyoruz, kisacasi memorydeki entitynin degerine bir flag atiyoruz, db lik herhangi bir islem yapilmadi
        {
            //_context.Entry(entity).State = EntityState.Deleted; | bu ile alttaki ayni isi yapiyor | deleted ile flag vermis oluyoruz
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entites) //asenkron degil
        {
            _dbset.RemoveRange(entites);
        }

        public void Update(T entity) //asenkron degil
        {
            _dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbset.Where(expression);
        }
    }
}
