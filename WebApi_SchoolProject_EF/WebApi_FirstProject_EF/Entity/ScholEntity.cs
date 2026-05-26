using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_FirstProject_EF.Entity
{
    [Table("Schools")]
    public class ScholEntity:BaseEntity
    {
        public required string Tittle { get; set; }

        public IEnumerable<ClassEntity>? Classes { get; set; }
    }
}
