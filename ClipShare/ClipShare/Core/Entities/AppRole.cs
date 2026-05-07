using Core.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AppRole : BaseProperties
    {
        [MaxLength(100)]
        public string RoleName { get; set; }
    }
}
