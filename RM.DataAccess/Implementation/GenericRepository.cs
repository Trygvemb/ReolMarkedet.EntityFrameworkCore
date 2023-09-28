using RM.DataAccess.Context;
using RM.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.DataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RMManagementDbContext _context;

        public GenericRepository(RMManagementDbContext context)
        {
            _context = context;
        }
        public void Add(T entitie)
        {
            _context.Set<T>().Add(entitie);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> prediction)
        {
            return _context.Set<T>().Where(prediction);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entitie)
        {
            _context.Set<T>().Remove(entitie);
        }

        public void RemoveRange(IEnumerable<T> enities)
        {
            _context.Set<T>().RemoveRange(enities);
        }
    }
}
