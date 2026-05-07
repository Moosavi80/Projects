using Core.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AppUser : BaseProperties
    {
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        //Clasess
        public Channel Channel { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Subscribe> Subscribetin { get; set; }
        public ICollection<LikeedOrNot> Likeeds { get; set; }
    }
}
