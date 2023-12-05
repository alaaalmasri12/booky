using Booky.BL.Interfaces;
using Booky.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.BL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {//DI => Inject Object Class inside Constructor From Onther Class
        private readonly BookyDbContext dbContext;

        public GenericRepository(BookyDbContext context)
        {
            dbContext = context;
        }
        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
          
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);

        }

        public IEnumerable<T> GetAll()
        {
           return  dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}
