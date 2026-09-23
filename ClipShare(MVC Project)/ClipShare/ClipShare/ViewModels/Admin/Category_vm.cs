using System.ComponentModel.DataAnnotations;

namespace ClipShare_Youtube_.ViewModels.Admin
{
    public class Category_vm
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
