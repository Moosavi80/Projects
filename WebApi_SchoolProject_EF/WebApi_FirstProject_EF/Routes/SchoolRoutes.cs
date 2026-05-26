using WebApi_FirstProject_EF.Response.User;
using WebApi_FirstProject_EF.Response;
using WebApi_FirstProject_EF.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_FirstProject_EF.Routes
{
    public static class SchoolRoutes
    {
        public static void MapSchoolRoutes(this IEndpointRouteBuilder app, string Tag)
        {
            var route = app.MapGroup("api/v1/");

            route.MapPost("School/Create", async ([FromServices] ISchoolService SchoolService, SchoolCreateParams service) =>
            {
                BaseResponse<SchoolResponseParams> res = await SchoolService.Create(service);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<SchoolResponseParams>>();

            route.MapGet("School/GetAllSchool", async ([FromServices] ISchoolService service) =>
            {
                BaseResponse<IEnumerable<SchoolResponseParams>> res = await service.GetAllSchool();
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<IEnumerable<SchoolResponseParams>>>();

            route.MapGet("School/GetSchoolById/{Id}", async ([FromServices] ISchoolService service, int Id) =>
            {
                BaseResponse<SchoolResponseParams> res = await service.GetSchoolById(Id);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<SchoolResponseParams>>();

            route.MapPut("School/Update", async ([FromServices] ISchoolService service, SchoolUpdateParams Params) =>
            {
                BaseResponse<SchoolResponseParams> res = await service.Update(Params);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<SchoolResponseParams>>();

            route.MapDelete("School/Delete", async ([FromServices] ISchoolService service, int Id) =>
            {
                BaseResponse res = await service.Delete(Id);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse>();
        }
    }
}
