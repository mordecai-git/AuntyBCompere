using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Services
{
    public class DetailsModel : PageModel
    {
        private readonly AuntyBCompere.Data.AuntyBCompereContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DetailsModel(AuntyBCompere.Data.AuntyBCompereContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public Service Service { get; set; }
                public IEnumerable<Testimonial> Testimonials { get; set; }

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
            Testimonials = await _context.Testimonials
                .OrderBy(x => Guid.NewGuid())
                .Take(6).ToListAsync();

            return Page();
        }

        public IActionResult OnGetGalleryImages(int id)
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/{id.ToString()}");

            var result = Directory.GetFiles(path)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/{id.ToString()}/{f}")   
                .ToList();

            return Partial("_GalleryImages", result);
        }
    }
}
