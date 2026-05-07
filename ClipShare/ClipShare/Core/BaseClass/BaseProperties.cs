using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseClass
{
    public class BaseProperties
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Del { get; set; } = false;
        public DateTime? ModifyDate { get; set; } = null;
    }
}
