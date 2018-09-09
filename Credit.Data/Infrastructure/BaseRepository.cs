using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Credit.Data.Infrastructure
{
    public class BaseRepository<T> where T : class
    {
        #region Fields

        internal Context context;
        internal DbSet<T> dbSet;

        #endregion

        #region Contructor

        public BaseRepository(Context context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        #endregion

        #region Methods

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IEnumerable<T> resultList;

            IQueryable<T> query = dbSet;

            if (null != filter)
            {
                query = query.Where(filter);
            }

            if (null != orderBy)
            {

                resultList = orderBy(query).ToList();
            }
            else
            {
                resultList = query.ToList();
            }

            return resultList;

        }


        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
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

        #endregion

    }
}
