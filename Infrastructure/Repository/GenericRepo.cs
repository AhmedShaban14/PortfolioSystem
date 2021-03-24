using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DataContext db;

        public GenericRepo(DataContext context)
        {
            db = context;
        }
        public void Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            db.Set<T>().Add(entity);
        }

        public void Delete(object id)
        {
            T entity = db.Set<T>().Find(id);
            if (entity == null)
                throw new ArgumentNullException();
            db.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            T entity = db.Set<T>().Find(id);
            if (entity == null)
                throw new ArgumentNullException();
            return entity;
        }

        public void Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
