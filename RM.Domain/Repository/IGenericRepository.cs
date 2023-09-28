using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RM.Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> prediction);
        void Add(T entitie);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entitie);
        void RemoveRange(IEnumerable<T> enities);
        
    }
}
