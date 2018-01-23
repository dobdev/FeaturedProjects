using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FeaturedProjects.Models.Database
{
    public class FPContext: DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public FPContext(): base("ProjectsConnection")
        {
        }
    }
}