using DataAccess.DTOs.Block;
using DataAccess.Models.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBlockServices
    {
        Task<bool> Insert(Block_InsUp dto, string userId);

        Task<bool> Update(Block_InsUp dto, string userId);

        Task<bool> Delete(string Id, string userId);

        Task<BlockResponse> GetById(string Id);

        Task<List<BlockResponse>> GetAll(Block_Search _Search);

        Task<bool> ChangeStatus(string Id, bool Status, string UserId);
    }
}
