using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeaturedProjects.Models
{
    [Table("Project")]
    public class Project
    {
        public int ID { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProductOwner { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]  
        public string ProjectLink { get; set; }

        public bool IsValid()
        {

            var isValid = true;

            if (this.ID != 0)
            {
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(this.Language))
            {
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(this.ProductOwner))
            {
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(this.ProjectLink))
            {
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(this.ProjectName))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}