using DataAccess.DTOs.OfficialExperts;
using DataAccess.Models.OfficialExperts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IOfficialExperts
    {
        Task<bool> Insert(OfficialExperts_InsUp dto, string userId);

        Task<bool> Update(OfficialExperts_InsUp dto, string userId);

        Task<bool> Delete(DeleteOfficialExpertsRequest deleteOfficialExperts, string userId);

        Task<OfficialExpertsResponse> GetById(GetOfficialExpertsById OfficialExpertsById);

        Task<List<OfficialExpertsResponse>> GetAll(OfficialExperts_Search _Search);

        Task<bool> ChangeStatus(ChangeStatusOfficialExperts changeStatus, string UserId);
    }
}
