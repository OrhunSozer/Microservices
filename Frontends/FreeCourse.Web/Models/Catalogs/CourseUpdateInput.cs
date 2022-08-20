using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FreeCourse.Web.Models.Catalogs
{
    public class CourseUpdateInput
    {
        public string Id { get; set; }
        [Display(Name = "Kurs Adı")]
        public string Name { get; set; }
        [Display(Name = "Kurs Açıklama")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Kurs resmi")]
        public string Picture { get; set; }
        public FeatureViewModel Feature { get; set; }
        [Display(Name = "Kurs Kategori")]
        public string CategoryId { get; set; }
        public IFormFile PhotoFormFile { get; set; }


    }
}
