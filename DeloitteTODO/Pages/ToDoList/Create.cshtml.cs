using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeloitteTODO.ApiModels;
using DeloitteTODO.Data;
using DeloitteTODO.Services;

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

            await _toDoService.AddAsync(ToDoItemDTO);

            return RedirectToPage("./Index");
        }
    }
}
