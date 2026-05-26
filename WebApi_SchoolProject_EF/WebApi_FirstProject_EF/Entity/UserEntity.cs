using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_FirstProject_EF.Entity
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public required string FullName { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(10)]
        public required string Mobile { get; set; }

        [Required]
        [MaxLength(10)]
        public required string Password { get; set; } = "1234";

        public DateTime? BirthDate { get; set; }


        public IEnumerable<ClassEntity>? Classes { get; set; }
    }
}
