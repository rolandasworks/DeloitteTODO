﻿using DeloitteTODO.ApiModels;
using DeloitteTODO.Models;
using DeloitteTODO.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteTODO.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {

        }

        public async Task<RedirectToPageResult> OnGetAsync()
        {
            return RedirectToPage("/ToDoList/Index");
        }
    }
}