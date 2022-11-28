using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages
{
    public class BookModel : PageModel
    {
        private readonly AuntyBCompereContext _context;
        public BookModel(AuntyBCompereContext context) { _context = context; }

        //public IEnumerable<Service> ServiceList { get; set; }

        [BindProperty]
        public Booking Booking { get; set; } = new Booking();

        public async Task OnGetAsync( )
        {
            _context.SaveChanges();

            Booking.Services = await _context.Services
                            .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync( )
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!Booking.Services.Any(x => x.IsSelected))
            {
                ModelState.AddModelError("serviceListError", "Please select at least one service.");
                return Page();
            }

            await _context.AddAsync(Booking);
            var bookingServices = Booking.Services.Where(x => x.IsSelected)
                .Select(x => new BookingService { Booking = Booking, ServiceId = x.Id });
            await _context.AddRangeAsync(bookingServices);

            await _context.SaveChangesAsync();

            TempData["SCC"] = "Appointment Booked Successfully.";

            return RedirectToPage("/book");
        }
    }

    public class BookingModel
    {
        public Booking Booking { get; set; }

    }
}
