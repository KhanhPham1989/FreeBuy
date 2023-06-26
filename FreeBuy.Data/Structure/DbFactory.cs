using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeBuy.Data.Structure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private FreeBuyDbContext dbcontext;

        protected override void DisposeCore()
        {
            if (dbcontext != null)
                dbcontext.Dispose();
        }

        public FreeBuyDbContext Init()
        {
            return dbcontext ?? (dbcontext = new FreeBuyDbContext());
        }
    }
}