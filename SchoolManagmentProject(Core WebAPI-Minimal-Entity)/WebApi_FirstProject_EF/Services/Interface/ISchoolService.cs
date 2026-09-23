using WebApi_FirstProject_EF.Response.User;
using WebApi_FirstProject_EF.Response;

namespace WebApi_FirstProject_EF.Services.Interface
{
    public interface ISchoolService
    {
        Task<BaseResponse<SchoolResponseParams>> Create(SchoolCreateParams user);
        Task<BaseResponse<IEnumerable<SchoolResponseParams>>> GetAllSchool();
        Task<BaseResponse<SchoolResponseParams>> GetSchoolById(int Id);
        Task<BaseResponse<SchoolResponseParams>> Update(SchoolUpdateParams user);
        Task<BaseResponse> Delete(int Id);
    }
}
