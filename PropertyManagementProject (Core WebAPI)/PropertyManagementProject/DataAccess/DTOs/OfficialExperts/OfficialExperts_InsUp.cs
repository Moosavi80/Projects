using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.OfficialExperts
{
    public class OfficialExperts_InsUp
    {
        [Required]
        public string OfficialExpertsNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FamilyName { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string ExpertLicenseNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string NationalNumber { get; set; } = string.Empty;

        [StringLength(14)]
        public string? MobileNumber { get; set; } = string.Empty;
    }
}
