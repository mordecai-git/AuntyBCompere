using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Services
{
    public class DetailsModel : PageModel
    {
        private readonly AuntyBCompere.Data.AuntyBCompereContext _context;

        public DetailsModel(AuntyBCompere.Data.AuntyBCompereContext context)
        {
            _context = context;
        }
        public Service Service { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            Service = service;
            return Page();
        }
    }
}
