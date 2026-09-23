using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class LikeedOrNot
    {
        public int AppUserId { get; set; }
        public int VideoId { get; set; }

        [Required]
        public bool Liked { get; set; } = false;

        //Clasess
        public AppUser AppUser { get; set; }
        public Video Video { get; set; }
    }
}
