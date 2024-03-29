﻿using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Testimonials;

public class ListModel : PageModel
{
    private readonly AuntyBCompereContext _context;

    public ListModel(AuntyBCompereContext context)
    {
        _context = context;
    }

    public IList<Testimonial> Testimonial { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Testimonials != null)
        {
            Testimonial = await _context.Testimonials
                                        .Include(t => t.Services).ToListAsync();
        }
    }
}