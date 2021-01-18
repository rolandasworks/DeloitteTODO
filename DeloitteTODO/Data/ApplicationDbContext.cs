using DeloitteTODO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeloitteTODO.ApiModels;

namespace DeloitteTODO.Data
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ToDoData> ToDoData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return this.Set<T>().SingleOrDefaultAsync(r => r.Id == id);
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return this.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await this.Set<T>().AddAsync(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        public Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            this.Entry(entity).State = EntityState.Modified;
            return this.SaveChangesAsync();
        }

        public Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            this.Set<T>().Remove(entity);
            return this.SaveChangesAsync();
        }

        public DbSet<DeloitteTODO.ApiModels.ToDoItemDTO> ToDoItemDTO { get; set; }
    }
}
