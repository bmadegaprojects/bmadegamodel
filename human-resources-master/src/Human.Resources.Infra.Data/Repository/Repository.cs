using Human.Resources.Domain.Entities;
using Human.Resources.Domain.Interfaces;
using Human.Resources.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Human.Resources.Infra.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity<T>
    {
        protected readonly HumanResourcesContext _context;
        protected DbSet<T> _dbSet { get; set; }

        protected Repository(HumanResourcesContext humanResourcesContext)
        {
            _context = humanResourcesContext;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IList<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<int> Insert(T obj)
        {
            _dbSet.Add(obj);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> Update(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual void Remove(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
