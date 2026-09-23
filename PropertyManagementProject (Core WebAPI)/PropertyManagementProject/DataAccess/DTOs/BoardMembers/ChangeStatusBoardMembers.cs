using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.BoardMembers
{
    public class ChangeStatusBoardMembers
    {
        public required string Number { get; set; }

        public required bool Status { get; set; }
    }
}
