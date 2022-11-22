using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuntyBCompere.Pages
{
    public class ServiceDetailsModel : PageModel
    {
        private readonly ILogger<ServiceDetailsModel> _logger;

        public ServiceDetailsModel(ILogger<ServiceDetailsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet( )
        {

        }
    }
}