
using System.ComponentModel.DataAnnotations;

namespace AuntyBCompere.Models.InputModels
{
    public class ImageModel
    {
        public int ServiceId { get; set; }

        public string Description { get; set; }

        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}