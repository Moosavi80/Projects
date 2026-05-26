using System.ComponentModel.DataAnnotations;
using WebApi_FirstProject_EF.Entity;

namespace WebApi_FirstProject_EF.Response.User
{
    public class UserUpdateParams
    {
        [Required]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public DateTime? BirthDate { get; set; }

        public IEnumerable<ClassEntity>? Classes { get; set; }
    }
}
