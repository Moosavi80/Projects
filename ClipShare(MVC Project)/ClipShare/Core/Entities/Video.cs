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
    public class Video : BaseEntity
    {
        [Required]
        [MaxLength(4000)]
        public string Url { get; set; }
        [Required]
        [MaxLength(100)]
        public string Tittle { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [MaxLength(1000)]
        public string ContentType { get; set; }
        [Required]
        public byte[] Contents { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ChannelId { get; set; }


        //Clasess
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("ChannelId")]
        public Channel Channel { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<LikeedOrNot> Likeeds { get; set; }

    }
}