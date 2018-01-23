using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeaturedProjects.Models.Database
{
    public class BaseService: IDisposable
    {
        protected FPContext dbContext;

        public BaseService()
        {
            Initialize();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        /// <summary>
        /// Initialize database service
        /// </summary>
        protected void Initialize()
        {
            dbContext = new FPContext();
            dbContext.Database.CreateIfNotExists();
        }
    }
}