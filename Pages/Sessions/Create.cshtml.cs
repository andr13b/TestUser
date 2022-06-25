using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestUser.Context;
using TestUser.Models;

namespace TestUser.Pages.Sessions
{
    public class CreateModel : PageModel
    {
        private readonly TestUser.Context.UsersDbContext _context;

        public CreateModel(TestUser.Context.UsersDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Session = new Session
            {
                UserID = (int)id
            };

            return Page();
        }

        [BindProperty]
        public Session Session { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sessions.Add(Session);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Users/Index");
        }
    }
}
