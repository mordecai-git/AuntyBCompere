using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;
        private readonly AuntyBCompereContext _context;

        public AboutModel(ILogger<AboutModel> logger, AuntyBCompereContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Testimonial> Testimonials { get; set; }

         public async Task<IActionResult> OnGetAsync( )
        {
            Testimonials = await _context.Testimonials
                .OrderBy(x => Guid.NewGuid())
                .Take(6).ToListAsync();

            return Page();
        }
    }
}