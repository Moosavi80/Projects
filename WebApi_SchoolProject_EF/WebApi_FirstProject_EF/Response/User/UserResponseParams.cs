using System.ComponentModel.DataAnnotations;
using WebApi_FirstProject_EF.Entity;

namespace WebApi_FirstProject_EF.Response
{
    public class UserResponseParams
    {
        public required string FullName { get; set; }
        public required string Mobile { get; set; }
        public required string Password { get; set; }
        public DateTime? BirthDate { get; set; }

        public IEnumerable<ClassEntity>? Classes { get; set; }
    }
}
