using System.ComponentModel.DataAnnotations;
using WebApi_FirstProject_EF.Entity;

namespace WebApi_FirstProject_EF.Response
{
    public class ClassResponseParams
    {
        public required string Tittle { get; set; }
        public required string Subject { get; set; }

        public int? SchoolId { get; set; }
        public ScholEntity? School { get; set; }

        public IEnumerable<UserEntity>? Users { get; set; }
    }
}
