using FreeBuy.Data.Respository;
using FreeBuy.Data.Structure;
using FreeBuy.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeBuy.UnitTest.RespositoryTest
{
    [TestClass]
    public class PostCategoryResposioryTest
    {
        private IDbFactory _dbFactory;
        private IUnitOfWork _unitOfWork;
        private IPostCategoryRespository _postCategoryRespository;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _dbFactory.Init();
            _unitOfWork = new UnitOfWork(_dbFactory);
            _postCategoryRespository = new PostCategoryRespository(_dbFactory);
        }

        [TestMethod]
        public void PostCategory_Test_Create()
        {
            PostCategory postcategory = new PostCategory();
            postcategory.Name = "Shoess";
            postcategory.Status = true;
            postcategory.Alias = "ACBB";
            var result = _postCategoryRespository.Add(postcategory);

            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.ID);
        }

        [TestMethod]
        public void PostCategory_Test_GetAll()
        {
            var result = _postCategoryRespository.GetAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }
    }
}