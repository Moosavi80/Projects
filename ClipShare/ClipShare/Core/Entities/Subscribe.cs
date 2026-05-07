using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Subscribe
    {
        public int AppUserId { get; set; }
        public int ChannelId { get; set; }


        //Clasess
        public AppUser AppUser { get; set; }
        public Channel Channel { get; set; }
    }
}
