using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeloitteTODO.Data;
using DeloitteTODO.Domain.DTO;
using DeloitteTODO.Domain.Interfaces;
using DeloitteTODO.Domain.Services;

namespace DeloitteTODO.Pages.ToDoList
{
    public class CreateModel : PageModel
    {
        private readonly IToDoService _toDoService;

        public CreateModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDoItemDTO ToDoItemDTO { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ToDoItemDTO.UserId = HttpContext.User.Claims.First().Value;

            await _toDoService.AddTodo(ToDoItemDTO);

            return RedirectToPage("./Index");
        }
    }
}
