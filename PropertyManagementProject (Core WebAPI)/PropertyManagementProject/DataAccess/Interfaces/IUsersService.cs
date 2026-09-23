using DataAccess.DTOs.Users;
using DataAccess.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUsersService
    {
        Task<bool> Insert(UserInsert_Update dto, string userId);

        Task<bool> Update(UserInsert_Update dto, string userId);

        Task<bool> Delete(string Id, string userId);

        Task<UserResponse> GetById(string Id);

        Task<List<UserResponse>> GetAll();

        Task<bool> ChangeStatus(string Id, bool Status, string UserId);
    }
}
