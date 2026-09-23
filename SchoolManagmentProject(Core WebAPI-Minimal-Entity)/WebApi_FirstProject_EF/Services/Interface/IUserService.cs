using WebApi_FirstProject_EF.Entity;
using WebApi_FirstProject_EF.Response;
using WebApi_FirstProject_EF.Response.User;

namespace WebApi_FirstProject_EF.Services.Interface
{
    public interface IUserService
    {
        Task<BaseResponse<UserResponseParams>> Create(UserCreateParams user);
        Task<BaseResponse<IEnumerable<UserResponseParams>>> GetAllUsers();
        Task<BaseResponse<UserResponseParams>> GetUsersById(int Id);
        Task<BaseResponse<UserResponseParams>> Update(UserUpdateParams user);
        Task<BaseResponse> Delete(int Id);
    }
}
