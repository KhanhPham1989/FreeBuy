using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeBuy.Data.Structure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private FreeBuyDbContext _dbContext;

        public FreeBuyDbContext DbContext
        {
            get { return _dbContext ?? (_dbContext = dbFactory.Init()); }
        }

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}