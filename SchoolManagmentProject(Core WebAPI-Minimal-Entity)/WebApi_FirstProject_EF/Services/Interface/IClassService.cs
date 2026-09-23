using WebApi_FirstProject_EF.Response.User;
using WebApi_FirstProject_EF.Response;

namespace WebApi_FirstProject_EF.Services.Interface
{
    public interface IClassService
    {
        Task<BaseResponse<ClassResponseParams>> Create(ClassCreateParams user);
        Task<BaseResponse<IEnumerable<ClassResponseParams>>> GetAllClass();
        Task<BaseResponse<ClassResponseParams>> GetClassById(int Id);
        Task<BaseResponse<ClassResponseParams>> Update(ClassUpdateParams user);
        Task<BaseResponse> Delete(int Id);
    }
}
