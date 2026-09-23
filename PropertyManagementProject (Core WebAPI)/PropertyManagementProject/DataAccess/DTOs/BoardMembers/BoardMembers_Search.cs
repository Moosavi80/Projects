using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.BoardMembers
{
    public class BoardMembers_Search
    {
        /// <summary>
        /// -1 => Default Value , 1 => FamilyName Search
        /// </summary>
        public required int Type { get; set; }

        /// <summary>
        /// 0 => Default Value , 1 => Active , 2 => DeActive
        /// </summary>
        public required int TypeStatus { get; set; }

        public required string Value { get; set; }

        /// <summary>
        /// Default Value => 1
        /// </summary>
        public required string Page { get; set; }

        /// <summary>
        /// Default Value => 10
        /// </summary>
        public required string OffSet { get; set; }
    }
}
