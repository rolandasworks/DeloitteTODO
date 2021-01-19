using DeloitteTODO.Domain.Entities;
using DeloitteTODO.Domain.Repositories;
using DeloitteTODO.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteTODO.Infrastructure.Repositories
{
    public class ToDoRepository : BaseRepository, IToDoRepository
    {
        public ToDoRepository(ApplicationDbContext dbContext) : base (dbContext)
        {

        }

        public Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(r => r.Id == id);
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public void UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
