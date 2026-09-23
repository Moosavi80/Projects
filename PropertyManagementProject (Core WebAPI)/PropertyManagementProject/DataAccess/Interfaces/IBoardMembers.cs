using DataAccess.DTOs.BoardMembers;
using DataAccess.Models.BoardMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBoardMembers
    {
        Task<bool> Insert(BoardMembers_InsUp dto, string userId);

        Task<bool> Update(BoardMembers_InsUp dto, string userId);

        Task<bool> Delete(DeleteBoardMembersRequest deleteBoardMembers, string userId);

        Task<BoardMembersResponse> GetById(GetBoardMembersById BoardMembersById);

        Task<List<BoardMembersResponse>> GetAll(BoardMembers_Search _Search);

        Task<bool> ChangeStatus(ChangeStatusBoardMembers changeStatus, string UserId);
    }
}
