using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeloitteTODO.Data;
using DeloitteTODO.Domain.DTO;
using DeloitteTODO.Domain.Interfaces;
using DeloitteTODO.Domain.Services;

namespace DeloitteTODO.Pages.ToDoList
{
    public class EditModel : PageModel
    {
        private readonly IToDoService _toDoService;

        public EditModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [BindProperty]
        public ToDoItemDTO ToDoItemDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoItemDTO = await _toDoService.GetTodoById(id.Value);

            if (ToDoItemDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _toDoService.UpdateTodo(ToDoItemDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
