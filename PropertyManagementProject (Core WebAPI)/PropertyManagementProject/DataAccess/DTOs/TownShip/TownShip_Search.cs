using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.TownShip
{
    public class TownShip_Search
    {
        /// <summary>
        /// 0 => Status Search , 1 => TownShip Search
        /// </summary>
        public required int Type { get; set; }

        public required string Value { get; set; }
    }
}
