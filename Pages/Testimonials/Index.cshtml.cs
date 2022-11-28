using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace AuntyBCompere.Pages.Testimonials;

public class IndexModel : PageModel
{
    private readonly AuntyBCompereContext _context;

    public IndexModel(AuntyBCompereContext context)
    {
        _context = context;
    }

    public IEnumerable<Testimonial> Testimonials { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Testimonials != null)
        {
            Testimonials = await _context.Testimonials.ToListAsync();
            //Testimonials = await _context.TestimonialServices
            //    .GroupBy(x => x.Testimonial)
            //    .AsEnumerable()
            //    .Select(x => new TestimonialModel
            //    {
            //        Item = x.First().Testimonial,
            //        Services = x.Select(s => s.Service.Name)
            //    }).OrderBy(x => x.Item.DateCreated).ToList();
                //.ToListAsync();
        }
    }

    public class TestimonialModel
    {
        public Testimonial Item { get; set; }
        public IEnumerable<string> Services { get; set; }
    }
} 