using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskApp.Data;
using TaskApp.Models;

namespace TaskApp.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly TaskApp.Data.AppDbContext _context;

        public DetailsModel(TaskApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public TaskItem TaskItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskitem = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);

            if (taskitem is not null)
            {
                TaskItem = taskitem;

                return Page();
            }

            return NotFound();
        }
    }
}
