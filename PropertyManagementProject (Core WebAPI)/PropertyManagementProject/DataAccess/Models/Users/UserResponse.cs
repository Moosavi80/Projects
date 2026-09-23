using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Users
{
    public class UserResponse
    {
        public string Number { get; set; } = string.Empty;

        public string UserType { get; set; } = string.Empty;

        public string UserGroup { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string FamilyName { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string NationalNumber { get; set; } = string.Empty;

        public string StatusText { get; set; } = string.Empty;

        public string UserAccess { get; set; } = string.Empty;

        public string FatherName { get; set; } = string.Empty;

        public DateTime? BirthDay { get; set; }

    }
}
