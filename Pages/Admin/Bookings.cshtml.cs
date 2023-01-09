using AuntyBCompere.Data;
using AuntyBCompere.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages.Admin
{
    public class BookingsModel : PageModel
    {
        private readonly AuntyBCompereContext _context;

        public BookingsModel(AuntyBCompereContext context)
        {
            _context = context;
        }

        public List<BookingView> Bookings { get; set; }

        public void OnGet()
        {

           Bookings = _context.Bookings
                .OrderBy(b => b.DateBooked)
                .Select(b => new BookingView
                {
                    Id= b.Id,
                    Name=b.Name,
                    Email=b.Email,
                    Phone=b.Phone,
                    Notes=b.Notes,
                    DateBooked  =b.DateBooked,
                    DateCreated= b.DateCreated,
                    ServicesBooked = b.BookingServices.Select(s => s.Service.Name).ToList()
                }).ToList();

            //foreach (var book in books)
            //{
            //    book.ServicesBooked = _context.BookingServices
            //        .Where(bs => bs.BookingId == book.Id)
            //        .Select(bs => bs.Service.Name)
            //        .ToList();
            //}
        }

        [BindProperty]
        public DataTableAjaxPostModel model { get; set; }

        public JsonResult OnPostSearchBookings()
        {
            return new JsonResult(new
            {
                // this is what datatables wants sending back
                draw = model.draw,
                recordsTotal = 20,
                recordsFiltered = 5,
                data = new List<BookingView>()
            });
        }
    }

    public class DataTableAjaxPostModel
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
}
