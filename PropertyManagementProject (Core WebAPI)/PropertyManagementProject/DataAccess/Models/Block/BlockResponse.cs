using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Block
{
    public class BlockResponse
    {
        public string BlockNumber { get; set; } = string.Empty;

        public string BlockName { get; set; } = string.Empty;

        public string TownShipName { get; set; } = string.Empty;

        public string StatusText { get; set; } = string.Empty;

        public string TotalCount { get; set; } = string.Empty;
    }
}
