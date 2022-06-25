using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestUser.Context;
using TestUser.Models;
using TestUser.Services;

namespace TestUser.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly TestUser.Context.UsersDbContext _context;
        
        private const int _pageSize = 4;

        public IndexModel(TestUser.Context.UsersDbContext context)
        {
            _context = context;
        }
        
        public string CurrentFilter { get; set; }
        public string DriversOnly { get; set; }
        public string TwoMoreSessions { get; set; }
        
        public PaginatedList<User> User { get; set; }

        public async Task OnGetAsync(string currentFilter, bool driversOnly, bool twoMoreSessions, int? pageNumber)
        {
            var queryUser = string.IsNullOrWhiteSpace(currentFilter)
                ? _context.Users
                : _context.Users.Where(u =>
                    u.Name.Contains(currentFilter) || u.Profession.Contains(currentFilter));

            if (driversOnly)
                queryUser = queryUser.Where(u => u.DriverLicense == true);
            
            // It could go long
            if(twoMoreSessions)
                queryUser = queryUser.Where(u => _context.Sessions.Count(s => s.UserID==u.ID) >= 2);

            //User = await queryUser.ToListAsync();
            
            User = await PaginatedList<User>.CreateAsync(
                queryUser.AsNoTracking(), pageNumber ?? 1, _pageSize);
        }
    }
}
