using FreeBuy.Data.Structure;
using FreeBuy.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeBuy.Data.Respository
{
    public interface IProductRespository
    {
        IEnumerable<Product> GetByAlias(string alias);
    }

    public class ProductRespository : RespositoryBase<Product>, IProductRespository
    {
        public ProductRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetByAlias(string alias)
        {
            return DbContext.Products.Where(x => x.Alias == alias);
        }
    }
}