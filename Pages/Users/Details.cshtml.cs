using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestUser.Context;
using TestUser.Models;

namespace TestUser.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly TestUser.Context.UsersDbContext _context;

        public DetailsModel(TestUser.Context.UsersDbContext context)
        {
            _context = context;
        }

        public User User { get; set; }
        public List<Session> Sessions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            Sessions = await _context.Sessions.Where(m => m.UserID == id).ToListAsync();

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
