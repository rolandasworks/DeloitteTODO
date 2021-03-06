﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeloitteTODO.Data;
using DeloitteTODO.Domain.DTO;
using DeloitteTODO.Domain.Interfaces;
using DeloitteTODO.Domain.Services;

namespace DeloitteTODO.Pages.ToDoList
{
    public class DeleteModel : PageModel
    {
        private readonly IToDoService _toDoService;

        public DeleteModel(IToDoService toDoService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _toDoService.DeleteTodo(ToDoItemDTO);

            return RedirectToPage("./Index");
        }
    }
}
