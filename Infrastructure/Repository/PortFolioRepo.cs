using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
   public class PortFolioRepo :GenericRepo<PortfolioItem>, IPortfolioItem
    {
        public PortFolioRepo(DataContext db):base(db)
        {
                
        }
    }
}
