using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.BoardMembers
{
    public class BoardMembers_InsUp
    {
        [Required]
        public string BoardMembersNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FamilyName { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string BirthCertificateNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string NationalNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FatherName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDay { get; set; }

        [StringLength(14)]
        public string? MobileNumber { get; set; } = string.Empty;
    }
}
