using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Plot
{
    public class PlotResponse
    {
        public string TownShipNumber { get; set; } = string.Empty;

        public string BlockNumber { get; set; } = string.Empty;

        public string PlotNumber { get; set; } = string.Empty;

        public string TownShipName { get; set; } = string.Empty;

        public string BlockName { get; set; } = string.Empty;

        public string PlotName { get; set; } = string.Empty;

        public string Area { get; set; } = string.Empty;

        public string LandUseTypeNumber { get; set; } = string.Empty;

        public string LandUseTypeName { get; set; } = string.Empty;

        public string CadastralNumber { get; set; } = string.Empty;

        public string StatusText { get; set; } = string.Empty;

        public string TotalCount { get; set; } = string.Empty;
    }
}
