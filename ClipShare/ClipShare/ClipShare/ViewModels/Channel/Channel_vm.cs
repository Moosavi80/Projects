using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClipShare_Youtube_.ViewModels.Channel
{
    public class Channel_vm
    {
        [Display(Name = "Channel Name")]
        [Required(ErrorMessage = "Name Is Required.")]
        [StringLength(150)]
        public string Name { get; set; } = "";

        [Display(Name = "About")]
        [Required(ErrorMessage = "About Is Required.")]
        [StringLength(500)]
        public string About { get; set; } = "";

        public string ChannelId { get; set; } = "0";
    }
}
