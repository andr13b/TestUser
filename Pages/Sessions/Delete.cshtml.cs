using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestUser.Context;
using TestUser.Models;

namespace TestUser.Pages.Sessions
{
    public class DeleteModel : PageModel
    {
        private readonly TestUser.Context.UsersDbContext _context;

        public DeleteModel(TestUser.Context.UsersDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Session Session { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Session = await _context.Sessions.FirstOrDefaultAsync(m => m.SessionID == id);

            if (Session == null)
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

            Session = await _context.Sessions.FindAsync(id);

            if (Session != null)
            {
                _context.Sessions.Remove(Session);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
