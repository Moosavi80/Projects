using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Users
{
    public class ChangeStatusUser
    {
        public required string Id { get; set; }
        public required bool Status { get; set; }
    }
}
