using DeloitteTODO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteTODO.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<ToDoData> ToDoData { get; set; }
        public Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;
        public Task<List<T>>ListAsync<T>() where T : BaseEntity;
        public Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        public Task UpdateAsync<T>(T entity) where T : BaseEntity;
        public Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}
