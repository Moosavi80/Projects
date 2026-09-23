using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Login
{
    public class ChangePasswordRequest
    {
        public required string NewUserName { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }

    }
}
