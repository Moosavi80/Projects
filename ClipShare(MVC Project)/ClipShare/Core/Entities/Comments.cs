using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Comments
    {
        public int AppUserId { get; set; }
        public int VideoId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.Now;

        //Clasess
        public AppUser AppUser { get; set; }
        public Video Video { get; set; }
    }
}
