using BookWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookContext _context;
        private readonly DbSet<T> _table;
        public Repository(BookContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }
        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetById(int id)
        {
            var entity = _table.Find(id);
            return entity;
        }

        //public T GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}
        //public T GetById(int id)
        //{
        //    return _table.AsNoTracking().FirstOrDefault(e => e.Id == id);
        //}

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
