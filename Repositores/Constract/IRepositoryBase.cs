using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositores.Constract
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool truckChanges);  

        T? FindByCondition(Expression<Func<T, bool>> expression, bool truckChanges); 


        void create(T entity);  

        void Remove(T entity);  

        void Update(T entity); 


    }
}
