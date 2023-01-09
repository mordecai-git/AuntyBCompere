using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace AuntyBCompere.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly AuntyBCompereContext _context;

        public GalleryModel(IWebHostEnvironment hostEnvironment, AuntyBCompereContext context)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }

        public List<string> MCCompere { get; set; }
        public List<string> AlagaIduro { get; set; }
        public List<string> Clown { get; set; }
        public List<string> Training { get; set; }
        public List<string> WeddingOfficiant { get; set; }

        public void OnGet()
        {
            string mCComperePath = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/1");
            string alagaIduroPath = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/2");
            string clownPath = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/3");
            string trainingPath = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/4");
            string weddingOfficiantPath = Path.Combine(_hostEnvironment.WebRootPath, $"img/services/10");

            MCCompere = Directory.GetFiles(mCComperePath)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/1/{f}")
                .OrderBy(a => Guid.NewGuid())
                .ToList();
            AlagaIduro = Directory.GetFiles(alagaIduroPath)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/2/{f}")
                .OrderBy(a => Guid.NewGuid())
                .ToList();
            Clown = Directory.GetFiles(clownPath)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/3/{f}")
                .OrderBy(a => Guid.NewGuid())
                .ToList();
            Training = Directory.GetFiles(trainingPath)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/4/{f}")
                .OrderBy(a => Guid.NewGuid())
                .ToList();
            WeddingOfficiant = Directory.GetFiles(weddingOfficiantPath)
                .Select(f => Path.GetFileName(f))
                .Select(f => $"img/services/10/{f}")
                .OrderBy(a => Guid.NewGuid())
                .ToList();

            var mcComperes = MCCompere.Select(f => new Gallery
            {
                ServiceId = 1,
                Name = "MC Compere",
                Description = "",
                Url = f,
            });
            var alagas = AlagaIduro.Select(f => new Gallery
            {
                ServiceId = 2,
                Name = "Alaga Iduro",
                Description = "",
                Url = f,
            });
            var clowns = Clown.Select(f => new Gallery
            {
                ServiceId = 3,
                Name = "Clowning and Costuming",
                Description = "",
                Url = f,
            });
            var training = Training.Select(f => new Gallery
            {
                ServiceId = 4,
                Name = "Trainnig and Mentoring",
                Description = "",
                Url = f,
            });
            var officiant = WeddingOfficiant.Select(f => new Gallery
            {
                ServiceId = 10,
                Name = "Weddig Officiating in the US.",
                Description = "",
                Url = f,
            });
        }
    }
}
