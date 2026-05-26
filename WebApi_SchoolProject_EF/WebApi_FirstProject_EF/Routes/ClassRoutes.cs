using WebApi_FirstProject_EF.Response.User;
using WebApi_FirstProject_EF.Response;
using WebApi_FirstProject_EF.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_FirstProject_EF.Routes
{
    public static class ClassRoutes
    {
        public static void MapClassRoutes(this IEndpointRouteBuilder app, string Tag)
        {
            var route = app.MapGroup("api/v1/");

            route.MapPost("Class/Create", async ([FromServices] IClassService ClassService, ClassCreateParams service) =>
            {
                BaseResponse<ClassResponseParams> res = await ClassService.Create(service);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<ClassResponseParams>>();

            route.MapGet("Class/GetAllClass", async ([FromServices] IClassService service) =>
            {
                BaseResponse<IEnumerable<ClassResponseParams>> res = await service.GetAllClass();
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<IEnumerable<ClassResponseParams>>>();

            route.MapGet("Class/GetClassById/{Id}", async ([FromServices] IClassService service, int Id) =>
            {
                BaseResponse<ClassResponseParams> res = await service.GetClassById(Id);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<ClassResponseParams>>();

            route.MapPut("Class/Update", async ([FromServices] IClassService service, ClassUpdateParams Params) =>
            {
                BaseResponse<ClassResponseParams> res = await service.Update(Params);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<ClassResponseParams>>();

            route.MapDelete("Class/Delete", async ([FromServices] IClassService service, int Id) =>
            {
                BaseResponse res = await service.Delete(Id);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse>();
        }
    }
}
