using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Testimonials;

public class DetailsModel : PageModel
{
    private readonly AuntyBCompereContext _context;

    public DetailsModel(AuntyBCompereContext context)
    {
        _context = context;
    }

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
}