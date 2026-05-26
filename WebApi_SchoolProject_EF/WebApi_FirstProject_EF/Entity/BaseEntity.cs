using System.ComponentModel.DataAnnotations;

namespace WebApi_FirstProject_EF.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public DateTime? RemoveAt { get; set; }
    }
}
