using Core.Entities;
using System.Linq;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
      public class OwnerRepo : GenericRepo<Owner> ,IOwnerRepo
    {
        private readonly DataContext db;

        public OwnerRepo(DataContext db):base(db)
        {
            this.db = db;
        }

        public Owner GetOwner()
        {
            var owner = db.Owners.FirstOrDefault();
            return owner;
        }
    }
}
