using Microsoft.EntityFrameworkCore;
using WebApi_FirstProject_EF.Data;
using WebApi_FirstProject_EF.Entity;
using WebApi_FirstProject_EF.Response;
using WebApi_FirstProject_EF.Response.User;
using WebApi_FirstProject_EF.Services.Interface;

namespace WebApi_FirstProject_EF.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly AppDbContext appDbContext;

        public SchoolService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<BaseResponse<SchoolResponseParams>> Create(SchoolCreateParams school)
        {
            ScholEntity entity = new() { Tittle = school.Tittle };

            ScholEntity schoolResponse = this.appDbContext.School.Add(entity).Entity;
            await this.appDbContext.SaveChangesAsync();

            SchoolResponseParams responseParams = new()
            {
                Tittle = schoolResponse.Tittle
            };

            return new BaseResponse<SchoolResponseParams>(responseParams);
        }

        public async Task<BaseResponse> Delete(int Id)
        {
            var find = await this.appDbContext.School.FirstOrDefaultAsync(x => x.Id == Id);

            List<ClassEntity> findclass = await this.appDbContext.Classes.Where(x => x.SchoolId == Id).ToListAsync();

            try
            {
                if (findclass != null)
                {
                    for (int i = 0; i < findclass.Count; ++i)
                    {
                        ClassEntity classEntity = findclass[i];
                        if (classEntity != null)
                        {
                            this.appDbContext.Classes.Remove(classEntity);
                            await this.appDbContext.SaveChangesAsync();
                        }
                    }
                }

                if (find != null)
                {
                    this.appDbContext.School.Remove(find);
                    await this.appDbContext.SaveChangesAsync();
                    return new BaseResponse();
                }
                else
                    return new BaseResponse(404, "School Not Found.");
            }
            catch (Exception ex) { return new BaseResponse(500, ex.Message); }
        }

        public async Task<BaseResponse<IEnumerable<SchoolResponseParams>>> GetAllSchool()
        {
            List<SchoolResponseParams> All = await this.appDbContext.School.Select(
                x => new SchoolResponseParams { Id = x.Id, Tittle = x.Tittle }).ToListAsync();

            return new BaseResponse<IEnumerable<SchoolResponseParams>>(All);
        }

        public async Task<BaseResponse<SchoolResponseParams>> GetSchoolById(int Id)
        {
            ScholEntity? school = await this.appDbContext.School.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (school == null)
                return new BaseResponse<SchoolResponseParams>(null, 404, "School Not Found");

            SchoolResponseParams Res = new() { Id = school.Id, Tittle = school.Tittle };
            return new BaseResponse<SchoolResponseParams>(Res);
        }

        public async Task<BaseResponse<SchoolResponseParams>> Update(SchoolUpdateParams school)
        {
            var find = await this.appDbContext.School.FirstOrDefaultAsync(x => x.Id == school.Id);

            if (find == null)
                return new BaseResponse<SchoolResponseParams>(null, 404, "School Not Found");

            if (school.Tittle != null) find.Tittle = school.Tittle;

            this.appDbContext.School.Update(find);
            await this.appDbContext.SaveChangesAsync();

            SchoolResponseParams responseParams = new() { Tittle = find.Tittle };

            return new BaseResponse<SchoolResponseParams>(responseParams);
        }
    }
}
