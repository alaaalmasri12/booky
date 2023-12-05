using Booky.BL.Interfaces;
using Booky.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.BL.Repositories
{
    public class UnitofWork : Iunitofwork,IDisposable
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public BookyDbContext _BookyDbContext { get; set; }

        public UnitofWork(BookyDbContext dbContext)
        {
            this.CategoryRepository = new CategoryRepository(dbContext);
            this._BookyDbContext=dbContext; 

        }
       public int savechanges()
        {
      return  _BookyDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _BookyDbContext.Dispose();
        }
    }
}
