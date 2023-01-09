using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;
using AuntyBCompere.Models.InputModels;
using AuntyBCompere.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Hosting;
using System.IO;

using Newtonsoft.Json;

using NuGet.Protocol.Plugins;

namespace AuntyBCompere.Pages.Admin
{
    public class GalleryModel : PageModel
    {
        private readonly AuntyBCompereContext _context;
        private readonly string basePath;
        private readonly List<string> acceptedFiles = new List<string> { ".jpg", ".jpeg", ".png" };

        public GalleryModel(AuntyBCompereContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            basePath = Path.Combine(hostEnvironment.WebRootPath, "img/services");
        }

        public List<Gallery> Galleries { get; set; }
        public List<ServiceView> Services { get; set; } = new List<ServiceView>();
        public SelectList ServiceList { get; set; }

        public void OnGet()
        {
            Services = _context.Services
                .Select(s => new ServiceView
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();

            ServiceList = new SelectList(Services, nameof(ServiceView.Id), nameof(ServiceView.Name));


        }

        public ActionResult OnGetServiceImages(int id)
        {
            // get gallery data from the database for the service id (recently added first)
            var images = _context.Galleries
                .Where(g => g.ServiceId == id)
                .ToList();

            return Partial("_GalleryImages", images);
        }

        public ActionResult OnPostAddImages(ImageModel model)
        {
            // validate the model
            string error = string.Empty;
            if (!model.Images.Any())
            {
                error = "Please select at least one image" + Environment.NewLine;
            }

            foreach (var file in model.Images)
            {
                if (file.Length <= 0 || file.Length > 2097152)
                {
                    error = "One or more files is invalid or too big."
                        + Environment.NewLine;
                    return new JsonResult(JsonConvert.SerializeObject(new
                    {
                        success = false,
                        data = "",
                        message = error
                    }));
                }
                string ext = Path.GetExtension(file.FileName)?.ToLowerInvariant();
                if (string.IsNullOrEmpty(ext) || !acceptedFiles.Contains(ext))
                {
                    error = "One or more file is invalid, " +
                        "please upload only a .jpg, .jpeg or .png" + Environment.NewLine;
                    return new JsonResult(JsonConvert.SerializeObject(new
                    {
                        success = false,
                        data = "",
                        message = error
                    }));
                }
            }

            if (model.ServiceId == 0 || string.IsNullOrEmpty(model.Description))
            {
                error = "Please select at least a service and give a little description"
                        + Environment.NewLine;
                return new JsonResult(JsonConvert.SerializeObject(new
                {
                    success = false,
                    data = "",
                    message = error
                }));
            }

            var result = new List<Gallery>();
            var toBeRemovedFiles = new List<string>();

            try
            {
                var service = _context.Services.Find(model.ServiceId);
                if (service == null)
                {
                    error = "Invalid service selected."
                        + Environment.NewLine;
                    return new JsonResult(JsonConvert.SerializeObject(new
                    {
                        success = false,
                        data = "",
                        message = error
                    }));
                }

                foreach (var file in model.Images)
                {
                    var fileGuid = Guid.NewGuid().ToString().ToLower();
                    string target = Path.Combine(basePath, service.Name);
                    if (!Directory.Exists(target))
                        Directory.CreateDirectory(target);

                    string fileName = $"{Guid.NewGuid().ToString().ToLower()}{Path.GetExtension(file.FileName)}";
                    string filePath = Path.Combine(target, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                        file.CopyTo(stream);

                    var gallery = new Gallery
                    {
                        ServiceId = service.Id,
                        Name = file.FileName,
                        Description = model.Description,
                        Url = $"img/services/{service.Name}/{fileName}"
                    };
                    _context.Add(gallery);
                    _context.SaveChanges();
                    result.Add(gallery);
                    toBeRemovedFiles.Add(filePath);
                }

                return new JsonResult(JsonConvert.SerializeObject(new
                {
                    success = true,
                    data = result,
                    message = "Image(s) uploaded successfully."
                }));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                // remove already added images when error occurs
                foreach (var filePath in toBeRemovedFiles)
                {
                    string path = Path.Combine(basePath, filePath);
                    var file = new FileInfo(path);
                    if (file.Exists)
                        file.Delete();
                }

                error = ex.Message + Environment.NewLine;
                return new JsonResult(JsonConvert.SerializeObject(new
                {
                    success = false,
                    data = "",
                    message = error
                }));
            }
        }

        public ActionResult OnPostDeleteImage(int imageId)
        {
            try
            {
                var gallery = _context.Galleries.Find(imageId);
                if (gallery == null)
                {
                    return new JsonResult(JsonConvert.SerializeObject(new
                    {
                        success = false,
                        message = "Inalid request, image does not exist"
                    }));
                }
                string path = Path.Combine(basePath, gallery.Url);
                var file = new FileInfo(path);
                if (file.Exists) file.Delete();

                _context.Remove(gallery);
                _context.SaveChanges();

                return new JsonResult(JsonConvert.SerializeObject(new
                {
                    success = false,
                    message = "Image deleted successfully."
                }));
            }
            catch (Exception ex)
            {
                return new JsonResult(JsonConvert.SerializeObject(new
                {
                    success = false,
                    message = ex.Message
                }));
            }
        }
    }
}