using DeloitteTODO.ApiModels;
using DeloitteTODO.Data;
using DeloitteTODO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteTODO.Services
{
    public class ToDoService : BaseService, IToDoService
    {
        public ToDoService(IApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<ToDoItemDTO> GetByIdAsync(int id)
        {
            var items = (await _dbContext.GetByIdAsync<ToDoData>(id)).ConvertObject();
            return items;
        }

        public async Task<List<ToDoItemDTO>> AsyncList(string userId)
        {
            var items = (await _dbContext.ListAsync<ToDoData>()).Where(r=>r.UserId == userId).Select(rec => rec.ConvertObject()).ToList();
            return items;
        }
                
        public async Task<bool> AddAsync(ToDoItemDTO toDoItemDTO)
        {
            await _dbContext.AddAsync(toDoItemDTO.ConvertObject());
            return true;
        }
        
        public async Task<bool> UpdateAsync(ToDoItemDTO toDoItemDTO)
        {
            await _dbContext.UpdateAsync(toDoItemDTO.ConvertObject());
            return true;
        }

        public async Task<bool> DeleteAsync(ToDoItemDTO toDoItemDTO)
        {
            await _dbContext.DeleteAsync(toDoItemDTO.ConvertObject());
            return true;
        }
    }
}
