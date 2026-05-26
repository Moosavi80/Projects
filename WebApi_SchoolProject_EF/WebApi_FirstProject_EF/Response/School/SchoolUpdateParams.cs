using System.ComponentModel.DataAnnotations;
using WebApi_FirstProject_EF.Entity;

namespace WebApi_FirstProject_EF.Response.User
{
    public class SchoolUpdateParams
    {
        [Required]
        public int Id { get; set; }
        public string? Tittle { get; set; }
        public IEnumerable<ClassEntity>? Classes { get; set; }
    }
}
