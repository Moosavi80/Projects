using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Plot
{
    public class Plot_Search
    {
        /// <summary>
        /// -1 => Default Value , 1 => TownShip Search , 2=> Block Search , 3=> Plots Search
        /// 4 => CadastralNumber Search , 5 => LandUseType Search , 6 => Area Search
        /// </summary>
        public required int Type { get; set; }

        /// <summary>
        /// -1 => Default Value , 0 => More Of , 1 => Between , 2 => Less Of
        /// </summary>
        public required int SubType { get; set; }

        /// <summary>
        /// 0 => Default Value , 1 => Active , 2 => DeActive
        /// </summary>
        public required int TypeStatus { get; set; }

        public required string Value { get; set; }

        /// <summary>
        /// This Prop For SubType.
        /// </summary>
        public required string SubValue { get; set; }

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
