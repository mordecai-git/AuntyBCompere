using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly AuntyBCompereContext _context;

        public IndexModel(AuntyBCompereContext context) => _context = context;

        public IEnumerable<Testimonial> Testimonials { get; set; }

        public async Task<IActionResult> OnGetAsync( )
        {
            Testimonials = await _context.Testimonials
                .Where(x => x.IsActive)
                .OrderBy(x => Guid.NewGuid())
                .Take(6).ToListAsync();

            return Page();
        }

    }
}
