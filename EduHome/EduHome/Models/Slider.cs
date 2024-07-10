using EduHome.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Slider : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile? file { get; set; }
    }
}
