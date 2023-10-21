using CheapBuyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CheapBuyAPI
{

    public class CheapBuyRepository<T>(CheapBuyDbContext context): ICheapBuyRepository<T> where T : class
    {
        internal CheapBuyDbContext context = context;
        internal DbSet<T> dbSet = context.Set<T>();

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public T? GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
