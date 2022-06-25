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
    public class DetailsModel : PageModel
    {
        private readonly TestUser.Context.UsersDbContext _context;

        public DetailsModel(TestUser.Context.UsersDbContext context)
        {
            _context = context;
        }

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
    }
}
