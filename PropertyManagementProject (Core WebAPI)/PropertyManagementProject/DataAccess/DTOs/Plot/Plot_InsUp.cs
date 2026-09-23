using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Plot
{
    public class Plot_InsUp
    {
        [Required]
        public string TownShipNumber { get; set; } = string.Empty;

        [Required]
        public string BlockNumber { get; set; } = string.Empty;

        [Required]
        public string PlotNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string PlotName { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string Area { get; set; } = string.Empty;

        [Required]
        public string LandUseType { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string CadastralNumber { get; set; } = string.Empty;
    }
}
