using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2FAtoLogin.Data
{
    public interface IRepository<T>
    {
        T SingleOrDefault(Expression<Func<T, bool>> filter);

        void Update(T entity);
    }
}
