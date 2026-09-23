using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.BoardMembers
{
    public class BoardMembersResponse
    {
        public string BoardMembersNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string FamilyName { get; set; } = string.Empty;

        public string BirthCertificateNumber { get; set; } = string.Empty;

        public string NationalNumber { get; set; } = string.Empty;

        public string FatherName { get; set; } = string.Empty;

        public DateTime? BirthDay { get; set; }

        public string MobileNumber { get; set; } = string.Empty;

        public string StatusText { get; set; } = string.Empty;

        public string TotalCount { get; set; } = string.Empty;
    }
}
