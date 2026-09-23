using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Block
{
    public class Block_InsUp
    {
        [Required]
        public string TownShipNumber { get; set; } = string.Empty;

        [Required]
        public string BlockNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string BlockName { get; set; } = string.Empty;
    }
}
