using System.ComponentModel.DataAnnotations;
using WebApi_FirstProject_EF.Entity;

namespace WebApi_FirstProject_EF.Response
{
    public class UserCreateParams
    {
        [Required]
        [MaxLength(50)]
        public required string FullName { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(10)]
        public required string Mobile { get; set; }

        public required string Password { get; set; }
        public DateTime? BirthDate { get; set; }

        public IEnumerable<ClassEntity>? Classes { get; set; }
    }
}
