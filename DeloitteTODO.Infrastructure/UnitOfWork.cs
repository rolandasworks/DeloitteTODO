using DeloitteTODO.Domain.Interfaces;
using DeloitteTODO.Domain.Repositories;
using DeloitteTODO.Infrastructure.Data;
using DeloitteTODO.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteTODO.Infrastructure
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private ToDoRepository _toDoRepository;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IToDoRepository ToDoRepository
        {
            get
            {
                if (_toDoRepository == null)
                {
                    _toDoRepository = new ToDoRepository(_dbContext);
                }
                return _toDoRepository;
            }
        }

        public Task Save()
        {
            return _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
