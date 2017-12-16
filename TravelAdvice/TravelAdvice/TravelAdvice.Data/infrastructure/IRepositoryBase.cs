using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvice.Domaine.infrastructure
{
    public interface IRepositoryBase<T>
   where T : class
    {
        void Add(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void Delete(T entity);


        T Get(Expression<Func<T, bool>> where);

        T GetById(int id);
        T GetById(string id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> orderBy = null);

        void Update(T entity);
        IEnumerable<T> GetAll();
    }
}
