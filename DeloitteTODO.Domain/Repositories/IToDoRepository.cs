using DeloitteTODO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteTODO.Domain.Repositories
{    
    public interface IToDoRepository
    {
        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        void UpdateAsync<T>(T entity) where T : BaseEntity;
        void DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}
