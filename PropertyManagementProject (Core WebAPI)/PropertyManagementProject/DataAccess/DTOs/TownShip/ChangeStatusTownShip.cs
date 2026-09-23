using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.TownShip
{
    public class ChangeStatusTownShip
    {
        public required string Number { get; set; }

        public required bool Status { get; set; }
    }
}
