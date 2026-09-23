using Core.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Channel : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string About { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int AppUserId { get; set; }

        //Clasess
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }

        public ICollection<Video> Video { get; set; }
        public ICollection<Subscribe> Subscribes { get; set; }
    }
}
