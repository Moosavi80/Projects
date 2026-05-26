using System.ComponentModel.DataAnnotations;
using WebApi_FirstProject_EF.Entity;

namespace WebApi_FirstProject_EF.Response.User
{
    public class ClassUpdateParams
    {
        [Required]
        public int Id { get; set; }
        public  string? Tittle { get; set; }
        public  string? Subject { get; set; }

        public int? SchoolId { get; set; }

        public IEnumerable<int>? Users { get; set; }
    }
}
