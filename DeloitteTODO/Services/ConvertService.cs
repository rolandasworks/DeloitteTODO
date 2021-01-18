using DeloitteTODO.ApiModels;
using DeloitteTODO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteTODO.Services
{
    public static class ConvertService
    {
        public static ToDoItemDTO ConvertObject(this ToDoData toDoData)
        {
            return new ToDoItemDTO()
            {
                Id = toDoData.Id,
                UserId = toDoData.UserId,
                Describtion = toDoData.Describtion,
                IsChecked = toDoData.IsChecked,
                Date = toDoData.Date
            };
        }

        public static ToDoData ConvertObject(this ToDoItemDTO toDoItemDTO)
        {
            return new ToDoData()
            {
                Id = toDoItemDTO.Id,
                UserId = toDoItemDTO.UserId,
                Describtion = toDoItemDTO.Describtion,
                IsChecked = toDoItemDTO.IsChecked,
                Date = toDoItemDTO.Date
            };
        }

    }
}
