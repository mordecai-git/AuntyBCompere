using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Testimonials;

public class EditModel : PageModel
{
    private readonly AuntyBCompereContext _context;

    public EditModel(AuntyBCompereContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Testimonial Testimonial { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Testimonials == null)
        {
            return NotFound();
        }

        var testimonial =  await _context.Testimonials.FirstOrDefaultAsync(m => m.Id == id);
        if (testimonial == null)
        {
            return NotFound();
        }
        Testimonial = testimonial;
        ViewData["ServiceId"] = new SelectList(_context.Set<Service>(), "Id", "Id");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Testimonial).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TestimonialExists(Testimonial.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool TestimonialExists(int id)
    {
        return _context.Testimonials.Any(e => e.Id == id);
    }
}