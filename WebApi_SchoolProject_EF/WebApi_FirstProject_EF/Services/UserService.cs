using Microsoft.EntityFrameworkCore;
using WebApi_FirstProject_EF.Data;
using WebApi_FirstProject_EF.Entity;
using WebApi_FirstProject_EF.Response;
using WebApi_FirstProject_EF.Response.User;
using WebApi_FirstProject_EF.Services.Interface;

namespace WebApi_FirstProject_EF.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<BaseResponse<UserResponseParams>> Create(UserCreateParams user)
        {
            UserEntity entity = new() { FullName = user.FullName, Mobile = user.Mobile, BirthDate = user.BirthDate, Password = user.Password };

            UserEntity userResponse = this.appDbContext.Users.Add(entity).Entity;
            await this.appDbContext.SaveChangesAsync();

            UserResponseParams responseParams = new()
            {
                FullName = userResponse.FullName,
                Mobile = userResponse.Mobile,
                BirthDate = userResponse.BirthDate,
                Password = userResponse.Password
            };

            return new BaseResponse<UserResponseParams>(responseParams);
        }

        public async Task<BaseResponse> Delete(int Id)
        {
            var user = await this.appDbContext.Users.FindAsync(Id);

            if (user != null)
            {
                this.appDbContext.Users.Remove(user);
                await this.appDbContext.SaveChangesAsync();
                return new BaseResponse();
            }
            else
                return new BaseResponse(404, "User Not Found.");
        }

        public async Task<BaseResponse<UserResponseParams>> GetUsersById(int Id)
        {
            UserEntity? User = await this.appDbContext.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (User == null)
                return new BaseResponse<UserResponseParams>(null, 404, "User Not Found.");

            UserResponseParams Res = new()
            {
                FullName = User.FullName,
                Mobile = User.Mobile,
                BirthDate = User.BirthDate,
                Password = User.Password
            };
            return new BaseResponse<UserResponseParams>(Res);
        }

        public async Task<BaseResponse<UserResponseParams>> Update(UserUpdateParams user)
        {
            var find = await this.appDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (find == null)
                return new BaseResponse<UserResponseParams>(null, 404, "User Not Found.");

            if (user.Mobile != null) find.Mobile = user.Mobile;
            if (user.FullName != null) find.FullName = user.FullName;
            if (user.BirthDate != null) find.BirthDate = user.BirthDate;
            if (user.Password != null) find.Password = user.Password;

            this.appDbContext.Users.Update(find);
            await this.appDbContext.SaveChangesAsync();

            UserResponseParams responseParams = new()
            {
                FullName = find.FullName,
                Mobile = find.Mobile,
                BirthDate = find.BirthDate,
                Password = find.Password
            };

            return new BaseResponse<UserResponseParams>(responseParams);
        }

        public async Task<BaseResponse<IEnumerable<UserResponseParams>>> GetAllUsers()
        {
            List<UserResponseParams> All = await this.appDbContext.Users.Select(
                x => new UserResponseParams
                {
                    FullName = x.FullName,
                    Mobile = x.Mobile,
                    BirthDate = x.BirthDate,
                    Password = x.Password
                }
                ).ToListAsync();

            return new BaseResponse<IEnumerable<UserResponseParams>>(All);
        }
    }
}
