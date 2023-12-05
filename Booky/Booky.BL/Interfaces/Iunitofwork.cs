using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.BL.Interfaces
{
    public interface Iunitofwork
    {
        public ICategoryRepository CategoryRepository { get; set; }

        public int savechanges();
    }
}
