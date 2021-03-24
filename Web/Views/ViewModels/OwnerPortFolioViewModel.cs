using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Views.ViewModels
{
    public class OwnerPortFolioViewModel
    {
        public Owner Owner { get; set; }

        public IEnumerable<PortfolioItem> PortfolioItems { get; set; }
    }
}
