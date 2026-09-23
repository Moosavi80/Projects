using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClipShare_Youtube_.ViewModels.Video
{
    public class AddEditVideo_vm
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Display(Name ="Upload Image here.")]
        public IFormFile ImageUpload { get; set; }

        [Display(Name = "Upload Video here.")]
        public IFormFile VideoUpload { get; set; }

        [Display(Name = "Choose the category for your Image/Video")]
        [Required(ErrorMessage ="Please Choose the Category!")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> CategoryDropDown { get; set; }

        public string ImageContentTypes { get; set; }

        public string VideoContentTypes { get; set; }

        public string ImageUrl { get; set; }
    }
}
