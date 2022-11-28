using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Testimonials;

public class CreateModel : PageModel
{
    private readonly AuntyBCompereContext _context;

    public CreateModel(AuntyBCompereContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Testimonial Testimonial { get; set; } = new Testimonial();


    public async Task<IActionResult> OnGetAsync( )
    {
        //ViewData["ServiceId"] = new SelectList(_context.Set<Service>(), "Id", "Name");
        Testimonial.Services = await _context.Services
                            .ToListAsync();
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync( )
    {
        bool invalid = false;
        if (!ModelState.IsValid)
            invalid = true;

        if (!Testimonial.Services.Any(x => x.IsSelected))
        {
            ModelState.AddModelError("serviceListError", "Please select at least one service.");
            invalid = true;
        }
        if (string.IsNullOrEmpty(Testimonial.Country) || Testimonial.Country == "-- select country --")
        {
            ModelState.AddModelError("countryListError", "Please select a valid country where Aunty 'B' served you.");
            invalid = true;
        }

        if (invalid) {
            Testimonial.Services = await _context.Services
                            .ToListAsync();
            return Page();
        }

        await _context.AddAsync(Testimonial);
        var testimonialServices = Testimonial.Services.Where(x => x.IsSelected)
            .Select(x => new TestimonialService { Testimonial = Testimonial, ServiceId = x.Id });
        await _context.AddRangeAsync(testimonialServices);

        await _context.SaveChangesAsync();

        TempData["SCC"] = "Your review has been added successfully.";
        return RedirectToPage("./create");
    }
}