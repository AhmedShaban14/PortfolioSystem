using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Views.ViewModels
{
    public class PortfolioItemViewModel : EntityBase
    {
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Required]
        public string Description { get; set; }

        [Display(Name = "Image Of Project")]
        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public string LinkUrl { get; set; }


    }
}
