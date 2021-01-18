using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeloitteTODO.ApiModels;
using DeloitteTODO.Data;
using DeloitteTODO.Services;

namespace DeloitteTODO.Pages.ToDoList
{
    public class IndexModel : PageModel
    {
        private readonly IToDoService _toDoService;

        public IndexModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public IList<ToDoItemDTO> ToDoItemDTO { get;set; }

        public async Task OnGetAsync()
        {
            ToDoItemDTO = await _toDoService.AsyncList(HttpContext.User.Claims.First().Value); 
        }
    }
}
