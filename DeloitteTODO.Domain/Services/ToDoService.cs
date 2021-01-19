using DeloitteTODO.Domain.DTO;
using DeloitteTODO.Domain.Entities;
using DeloitteTODO.Domain.Interfaces;
using DeloitteTODO.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteTODO.Domain.Services
{
    public interface IToDoService
    {
        public Task<ToDoItemDTO> GetTodoById(int id);
        public Task<List<ToDoItemDTO>> GetList(string userId);
        public Task<bool> AddTodo(ToDoItemDTO toDoItemDTO);
        public Task<bool> UpdateTodo(ToDoItemDTO toDoItemDTO);
        public Task<bool> DeleteTodo(ToDoItemDTO toDoItemDTO);
    }


    public class ToDoService : BaseService, IToDoService
    {
        public ToDoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<ToDoItemDTO> GetTodoById(int id)
        {
            var items = (await _unitOfWork.ToDoRepository.GetByIdAsync<ToDoData>(id)).ConvertObject();
            return items;
        }

        public async Task<List<ToDoItemDTO>> GetList(string userId)
        {
            var items = (await _unitOfWork.ToDoRepository.ListAsync<ToDoData>()).Where(r => r.UserId == userId).Select(rec => rec.ConvertObject()).ToList();
            return items;
        }

        public async Task<bool> AddTodo(ToDoItemDTO toDoItemDTO)
        {
            await _unitOfWork.ToDoRepository.AddAsync(toDoItemDTO.ConvertObject());
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> UpdateTodo(ToDoItemDTO toDoItemDTO)
        {
            _unitOfWork.ToDoRepository.UpdateAsync(toDoItemDTO.ConvertObject());
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> DeleteTodo(ToDoItemDTO toDoItemDTO)
        {
            _unitOfWork.ToDoRepository.DeleteAsync(toDoItemDTO.ConvertObject());
            await _unitOfWork.Save();
            return true;
        }
    }
}
