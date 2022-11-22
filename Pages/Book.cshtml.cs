using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuntyBCompere.Pages
{
    public class BookModel : PageModel
    {
        public IEnumerable<Service> ServiceList { get; set; }
        public Booking Booking { get; set; }

        public async Task OnGetAsync()
        {
            ServiceList = new List<Service>
            {
                new() {Id = 1, Name = "Event MC/Compere"}, new() {Id = 2, Name = "Wedding Planner"}
            };
        }
    }
}
