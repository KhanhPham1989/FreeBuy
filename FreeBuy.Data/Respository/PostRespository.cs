using FreeBuy.Data.Structure;
using FreeBuy.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeBuy.Data.Respository
{
    public interface IPostRespository : IRespository<Post>
    {
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
    }

    public class PostRespository : RespositoryBase<Post>, IPostRespository
    {
        public PostRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID.Equals(tag)
                        select p;

            totalRow = query.Count();
            query = query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}