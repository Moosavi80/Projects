using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.OfficialExperts
{
    public class OfficialExpertsResponse
    {
        public string OfficialExpertsNumber { get; set; } = string.Empty;

        public string Name_Family { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Family { get; set; } = string.Empty;

        public string NationalNumber { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string ExpertLicenseNumber { get; set; } = string.Empty;

        public string StatusText { get; set; } = string.Empty;

        public string TotalCount { get; set; } = string.Empty;
    }
}
