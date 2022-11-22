using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuntyBCompere.Pages.Testimonials;

public class CreateModel : PageModel
{
    private readonly AuntyBCompereContext _context;

    public CreateModel(AuntyBCompereContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["ServiceId"] = new SelectList(_context.Set<Service>(), "Id", "Id");
        return Page();
    }

    [BindProperty]
    public Testimonial Testimonial { get; set; }
        

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Testimonials.Add(Testimonial);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}