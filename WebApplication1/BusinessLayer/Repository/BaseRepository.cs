using BusinessLayer.Inerfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserApp.datalayer;
using UserApp.DataLayer.Entities;

namespace BusinessLayer.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public virtual async Task<TEntity?> GetByPublicIdAsync(Guid publicId)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(t => t.PublicId == publicId);
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id == id);
        }


        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }


        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }


        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateAll(List<TEntity> entityList)
        {
            _context.Set<TEntity>().AddRange(entityList);
        }


        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void DeleteAll(List<TEntity> entityList)
        {
            _context.Set<TEntity>().RemoveRange(entityList);
        }


        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
