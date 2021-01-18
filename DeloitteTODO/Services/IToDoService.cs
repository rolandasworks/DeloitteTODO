using DeloitteTODO.ApiModels;
using DeloitteTODO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteTODO.Services
{
    public interface IToDoService
    {
        public Task<ToDoItemDTO> GetByIdAsync(int id);
        public Task<List<ToDoItemDTO>> AsyncList(string userId);
        public Task<bool> AddAsync(ToDoItemDTO toDoItemDTO);
        public Task<bool> UpdateAsync(ToDoItemDTO toDoItemDTO);
        public Task<bool> DeleteAsync(ToDoItemDTO toDoItemDTO);
    }
}
