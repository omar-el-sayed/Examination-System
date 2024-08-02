using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(e => !e.IsDeleted);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public T? GetById(int id)
        {
            //return _context.Set<T>().Find(id); //Uses context's cache
            return GetAll().FirstOrDefault(e => e.Id == id); //Always queries the database
        }

        public T? GetByIdWithTracking(int id)
        {
            return _context.Set<T>()
                .Where(e => !e.IsDeleted && e.Id == id)
                .AsTracking()
                .FirstOrDefault();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            //_context.Set<T>().Remove(entity); //Hard Delete
            //Soft Delete
            entity.IsDeleted = true;
            Update(entity);
        }

        public void HardDelete(int id)
        {
            _context.Set<T>().Where(e => e.Id == id).ExecuteDelete(); //Go to DB once
        }

        public int Min(Func<T, int> selector)
            => GetAll().Min(selector);

        public int Max(Func<T, int> selector)
             => GetAll().Max(selector);

        public int Count()
            => GetAll().Count();

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
