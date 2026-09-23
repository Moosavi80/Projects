using DataAccess.DTOs.Plot;
using DataAccess.Models.Plot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IPlotServices
    {
        Task<bool> Insert(Plot_InsUp dto, string userId);

        Task<bool> Update(Plot_InsUp dto, string userId);

        Task<bool> Delete(DeletePlotRequest deletePlot, string userId);

        Task<PlotResponse> GetById(GetPlotsById plotsById);

        Task<List<PlotResponse>> GetAll(Plot_Search _Search);

        Task<bool> ChangeStatus(ChangeStatusPlot changeStatus, string UserId);

        Task<List<LandUseTypeResponse>> GetLandUseType();

    }
}
