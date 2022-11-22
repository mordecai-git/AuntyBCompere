using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly AuntyBCompere.Data.AuntyBCompereContext _context;

        public IndexModel(AuntyBCompere.Data.AuntyBCompereContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                User = await _context.Users.ToListAsync();
            }
        }
    }
}
