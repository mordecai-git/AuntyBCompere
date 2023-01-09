using AuntyBCompere.Data;
using AuntyBCompere.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Admin
{
    public class TestimonialsModel : PageModel
    {
        private readonly AuntyBCompereContext _context;

        public TestimonialsModel(AuntyBCompereContext context)
        {
            _context = context;
        }

        public List<TestimonialView> Testimonials { get; set; } = new List<TestimonialView>();

        public void OnGet()
        {
            Testimonials = _context.Testimonials
                .OrderByDescending(t => t.DateCreated) 
                .Select (t => new TestimonialView
                {
                    Id  = t.Id,
                    Name = t.Name,
                    Email = t.Email,
                    Content= t.Content,
                    Country = t.Country,
                    Rating= t.Rating,
                    DateCreated= t.DateCreated,
                    IsActive = t.IsActive,
                    Services = t.TestimonialServices.Select(s => s.Service.Name).ToList()
                }).ToList();
        }

        public async Task OnPostActivate(int id)
        {
            var testimonial = await _context.Testimonials
                .FindAsync(id);
            testimonial.IsActive = true;
            await _context.SaveChangesAsync();

            TempData["SCC"] = "Testimonial activated successfully";

           Response.Redirect("/admin/testimonials");
        }

        public async Task OnPostDeactivate(int id)
        {
            var testimonial = await _context.Testimonials
                .FindAsync(id);
            testimonial.IsActive = false;
            await _context.SaveChangesAsync();

            TempData["SCC"] = "Testimonial activated successfully";

           Response.Redirect("/admin/testimonials");
        }
    }
}
