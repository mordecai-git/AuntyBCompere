using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace AuntyBCompere.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public GalleryModel(IWebHostEnvironment hostEnvironment) => _hostEnvironment = hostEnvironment;

        public List<string> MCCompere { get; set; }
        public List<string> AlagaIduro { get; set; }
        public List<string> Clown { get; set; }
        public List<string> Training { get; set; }

        public void OnGet()
        {
            string mCComperePath = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/1");
            string alagaIduroPath = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/2");
            string clownPath = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/3");
            string trainingPath = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/4");

            MCCompere = Directory.GetFiles(mCComperePath)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/1/{f}")   
                .ToList();
            AlagaIduro = Directory.GetFiles(alagaIduroPath)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/2/{f}")   
                .ToList();
            Clown = Directory.GetFiles(clownPath)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/3/{f}")   
                .ToList();
            Training = Directory.GetFiles(trainingPath)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/4/{f}")   
                .ToList();
        }
    }
}
