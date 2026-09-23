using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.TownShip
{
    public class TownShipResponse
    {
        public string Number { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string StatusText { get; set; } = string.Empty;
    }
}
