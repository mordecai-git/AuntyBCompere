using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AuntyBCompereContext _context;

        public IndexModel(ILogger<IndexModel> logger, AuntyBCompereContext context)
        {
            _logger = logger; _context = context;
        }

        public IEnumerable<Testimonial> Testimonials { get; set; }

        public async Task<IActionResult> OnGetAsync( )
        {
            Testimonials = await _context.Testimonials
                .Where(x => x.IsActive)
                .OrderBy(x => Guid.NewGuid())
                .Take(6).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnGetGallery( )
        {
            return Partial("~/Pages/Partials/_Gallery.cshtml");
        }
    }
}