using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeBuy.Data.Structure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}