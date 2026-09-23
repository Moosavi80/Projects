using Microsoft.EntityFrameworkCore;
using WebApi_FirstProject_EF.Data;
using WebApi_FirstProject_EF.Entity;
using WebApi_FirstProject_EF.Response;
using WebApi_FirstProject_EF.Response.User;
using WebApi_FirstProject_EF.Services.Interface;

namespace WebApi_FirstProject_EF.Services
{
    public class ClassService : IClassService
    {
        private readonly AppDbContext appDbContext;

        public ClassService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<BaseResponse<ClassResponseParams>> Create(ClassCreateParams classes)
        {
            List<UserEntity> Userlist = new();

            if (classes.Users != null)
            {
                foreach (int userid in classes.Users)
                {
                    var user = await this.appDbContext.Users.FirstOrDefaultAsync(x => x.Id == userid);
                    if (user != null) { Userlist.Add(user); }
                }
            }

            ClassEntity entity = new() { SchoolId = classes.SchoolId, Subject = classes.Subject, Tittle = classes.Tittle };

            ClassEntity ClassResponse = this.appDbContext.Classes.Add(entity).Entity;
            await this.appDbContext.SaveChangesAsync();

            ClassResponseParams Params = new()
            {
                Subject = ClassResponse.Subject,
                Tittle = ClassResponse.Tittle,
                Users = Userlist
            };

            return new BaseResponse<ClassResponseParams>(Params, 200, "");
        }

        public async Task<BaseResponse> Delete(int Id)
        {
            var classes = await this.appDbContext.Classes.FindAsync(Id);

            if (classes != null)
            {
                this.appDbContext.Classes.Remove(classes);
                await this.appDbContext.SaveChangesAsync();
                return new BaseResponse();
            }
            else
                return new BaseResponse(404, "Class Not Found.");
        }

        public async Task<BaseResponse<IEnumerable<ClassResponseParams>>> GetAllClass()
        {
            List<ClassResponseParams> All = await this.appDbContext.Classes.Select(
                x => new ClassResponseParams { Subject = x.Subject, Tittle = x.Tittle }
                ).ToListAsync();

            return new BaseResponse<IEnumerable<ClassResponseParams>>(All, 200, "");
        }

        public async Task<BaseResponse<ClassResponseParams>> GetClassById(int Id)
        {
            ClassEntity? classes = await this.appDbContext.Classes.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (classes == null)
                return new BaseResponse<ClassResponseParams>(null, 404, "User Not Found");

            ClassResponseParams Res = new() { Tittle = classes.Tittle, Subject = classes.Subject };

            return new BaseResponse<ClassResponseParams>(Res, 200, "");
        }

        public async Task<BaseResponse<ClassResponseParams>> Update(ClassUpdateParams classes)
        {
            var find = await this.appDbContext.Classes.FirstOrDefaultAsync(x => x.Id == classes.Id);

            if (find == null)
                return new BaseResponse<ClassResponseParams>(null, 404, "User Not Found");

            if (classes.Subject != null) find.Subject = classes.Subject;
            if (classes.Tittle != null) find.Tittle = classes.Tittle;

            this.appDbContext.Classes.Update(find);
            await this.appDbContext.SaveChangesAsync();

            ClassResponseParams responseParams = new() { Tittle = find.Tittle, Subject = find.Subject };

            return new BaseResponse<ClassResponseParams>(responseParams, 200, "");
        }
    }
}
