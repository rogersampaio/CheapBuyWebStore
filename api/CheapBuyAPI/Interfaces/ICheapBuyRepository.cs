using System.Linq.Expressions;

namespace CheapBuyAPI.Interfaces
{
    public interface ICheapBuyRepository<T> where T : class
    {
        T? GetById(object id);
        IEnumerable<T> Get(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
