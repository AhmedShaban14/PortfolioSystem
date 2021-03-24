using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext db;

        public UnitOfWork(DataContext db)
        {
            this.db = db;
            Owners = new OwnerRepo(db);
            PortfolioItems = new PortFolioRepo(db);

        }
        public IOwnerRepo Owners { get; private set; }
        public IPortfolioItem PortfolioItems { get; private set; }


        public void Dispose()
        {
            db.Dispose();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
