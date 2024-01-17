using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

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
    }
}