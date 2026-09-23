using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Block
{
    public class ChangeStatusBlock
    {
        public required string Number { get; set; }

        public required bool Status { get; set; }
    }
}
