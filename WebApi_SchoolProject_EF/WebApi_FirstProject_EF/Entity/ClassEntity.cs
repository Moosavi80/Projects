using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_FirstProject_EF.Entity
{
    [Table("Classes")]
    public class ClassEntity : BaseEntity
    {
        public required string Tittle { get; set; }
        public required string Subject { get; set; }

        public int SchoolId { get; set; }
        public ScholEntity? School { get; set; }

        public IEnumerable<UserEntity>? Users { get; set; }
    }
}
