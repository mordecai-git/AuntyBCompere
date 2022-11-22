using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Services
{
    public class DeleteModel : PageModel
    {
        private readonly AuntyBCompere.Data.AuntyBCompereContext _context;

        public DeleteModel(AuntyBCompere.Data.AuntyBCompereContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Service Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);

            if (service == null)
            {
                return NotFound();
            }
            else 
            {
                Service = service;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }
            var service = await _context.Services.FindAsync(id);

            if (service != null)
            {
                Service = service;
                _context.Services.Remove(Service);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
