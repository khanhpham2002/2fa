using _2FAtoLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core;

namespace _2FAtoLogin.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        public IDbContext DbContext { get; private set; }

        protected Repository(IDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public T SingleOrDefault(Expression<Func<T, bool>> filter)
        {
            return DbContext.Set<T>().SingleOrDefault(filter);
        }

        public void Update(T entity)
        {
            var entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
                entry.State = EntityState.Modified;
            }
            DbContext.SaveChanges();
        }
        public virtual void Add(T entity)
        {
            ((IDbSet<T>)DbContext.Set<T>()).Add(entity);
            DbContext.SaveChanges();
        }
    }
}