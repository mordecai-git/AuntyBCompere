using AuntyBCompere.Data;
using AuntyBCompere.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Admin
{
    public class ServicesModel : PageModel
    {
        private readonly AuntyBCompereContext _context;

        public ServicesModel(AuntyBCompereContext context)
        {
            _context = context;
        }

        public List<ServiceView> Services { get; set; } = new List<ServiceView>();

        public void OnGet()
        {
            Services = _context.Services
                .Select(s => new ServiceView
                {
                    Id = s.Id,
                    Name = s.Name,
                    Tagline= s.Tagline,
                    FaIcon = s.FaIcon,
                    Summary = s.Summary,
                    Content = s.Content,
                    IsStandard = s.IsStandard
                }).ToList();

            int sd = 32;
        }
    }
}
