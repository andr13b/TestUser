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
    public class IndexModel : PageModel
    {
        private readonly TestUser.Context.UsersDbContext _context;

        public IndexModel(TestUser.Context.UsersDbContext context)
        {
            _context = context;
        }

        public IList<Session> Session { get;set; }

        public async Task OnGetAsync()
        {
            Session = await _context.Sessions.ToListAsync();
        }
    }
}
