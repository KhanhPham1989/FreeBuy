using FreeBuy.Data.Respository;
using FreeBuy.Data.Structure;
using FreeBuy.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeBuy.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

        Post GetById(int id);

        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }

    public class PostService : IPostService
    {
        private readonly IPostRespository _postRespository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRespository postRespository, IUnitOfWork unitOfWork)
        {
            _postRespository = postRespository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRespository.Add(post);
        }

        public void Delete(int id)
        {
            _postRespository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRespository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _postRespository.GetAllByTagPaging(tag, page, pageSize, out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRespository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRespository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRespository.Update(post);
        }
    }
}