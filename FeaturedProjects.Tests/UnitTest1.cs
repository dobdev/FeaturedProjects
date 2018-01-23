using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeaturedProjects.Models.Github;
using FeaturedProjects.Models.Database;
using FeaturedProjects.Models;
using System.Threading.Tasks;

namespace FeaturedProjects.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGitHibService()
        {
            try
            {
                var service = new GitHubService();
                var result = service.Synchronize();
                Assert.AreEqual(result, result);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Assert.Fail();
            }
        }
    }
}
