using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Testimonials;

public class DeleteModel : PageModel
{
    private readonly AuntyBCompereContext _context;

    public DeleteModel(AuntyBCompereContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Testimonial Testimonial { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Testimonials == null)
        {
            return NotFound();
        }

        var testimonial = await _context.Testimonials.FirstOrDefaultAsync(m => m.Id == id);

        if (testimonial == null)
        {
            return NotFound();
        }
        else 
        {
            Testimonial = testimonial;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Testimonials == null)
        {
            return NotFound();
        }
        var testimonial = await _context.Testimonials.FindAsync(id);

        if (testimonial != null)
        {
            Testimonial = testimonial;
            _context.Testimonials.Remove(Testimonial);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}