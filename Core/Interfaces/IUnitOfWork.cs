using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IOwnerRepo Owners { get; }
        IPortfolioItem PortfolioItems { get; }

        void SaveChanges();
    }
}
