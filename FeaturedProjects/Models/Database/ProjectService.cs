using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FeaturedProjects.Models.Database
{
    public class ProjectService: BaseService
    {
        public ProjectService(): base()
        {   
            
        }

        public bool Add(Project proj)
        {
            if (proj.IsValid())
            {
                dbContext.Projects.Add(proj);
                var state = (EntityState) dbContext.SaveChanges();

                if (state == EntityState.Added)
                {
                    return true;
                }
            }

            return false;
        }
        
        public IQueryable<Project> GetAll()
        {
            return dbContext.Projects;
        }

        public void CleanAll()
        {
            dbContext.Database.ExecuteSqlCommand("DELETE FROM TABLE [Project]");
        }
    }
}