using DataAccess.DTOs.TownShip;
using DataAccess.Models.TownShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ITownShipServices
    {
        Task<bool> Insert(TownShip_InsUp dto, string userId);

        Task<bool> Update(TownShip_InsUp dto, string userId);

        Task<bool> Delete(string Id, string userId);

        Task<TownShipResponse> GetById(string Id);

        Task<List<TownShipResponse>> GetAll();

        Task<bool> ChangeStatus(string Id, bool Status, string UserId);

        Task<List<TownShipResponse>> TownShipSearch(TownShip_Search _Search);
    }
}
