using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Users
{
    public class UserInsert_Update
    {
        [Required]
        public string ID { get; set; } = string.Empty;

        [Required]
        public bool UserType { get; set; }

        [Required]
        public int UserGroup { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(70)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FamilyName { get; set; } = string.Empty;

        [StringLength(14)]
        public string? MobileNumber { get; set; }

        [Required]
        [StringLength(15)]
        public string NationalNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(70)]
        public string FatherName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public string UserAccess { get; set; } = string.Empty;
    }
}
