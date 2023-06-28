using FreeBuy.Data.Respository;
using FreeBuy.Data.Structure;
using FreeBuy.Model.Models;
using FreeBuy.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeBuy.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRespository> mock_PostCategoryRespo;
        private Mock<IUnitOfWork> mock_UniofWork;
        private IPostCategoryService postCategoryService;
        private List<PostCategory> _listPostCategory;

        [TestInitialize]
        public void Initialize()
        {
            mock_UniofWork = new Mock<IUnitOfWork>();
            mock_PostCategoryRespo = new Mock<IPostCategoryRespository>();
            postCategoryService = new PostCategoryService(mock_PostCategoryRespo.Object, mock_UniofWork.Object);
            _listPostCategory = new List<PostCategory>()
            {
                new PostCategory() {ID =1 ,Name="DM1",Status=true },
                new PostCategory() {ID =2 ,Name="DM2",Status=true },
                new PostCategory() {ID =3 ,Name="DM3",Status=true },
            };
        }

        [TestMethod]
        public void PostCategoryService_Test_GetAll()
        {
            mock_PostCategoryRespo.Setup(x => x.GetAll(null)).Returns(_listPostCategory);

            var result = postCategoryService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void PostCategoryService_Test_Create()
        {
            PostCategory postCategory = new PostCategory()
            {
                Name = "Test A",
                Alias = "Test A",
                Status = false
            };
            mock_PostCategoryRespo.Setup(x => x.Add(postCategory)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });

            var result = postCategoryService.Add(postCategory);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}