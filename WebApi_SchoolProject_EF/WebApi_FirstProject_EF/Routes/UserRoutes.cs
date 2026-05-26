using Microsoft.AspNetCore.Mvc;
using WebApi_FirstProject_EF.Response.User;
using WebApi_FirstProject_EF.Response;
using WebApi_FirstProject_EF.Services.Interface;

namespace WebApi_FirstProject_EF.Routes
{
    public static class UserRoutes
    {
        public static void MapUserRoutes(this IEndpointRouteBuilder routeBuilder, string Tag)
        {
            var route = routeBuilder.MapGroup("api/v1/");

            route.MapPost("User/Create", async ([FromServices] IUserService userService, UserCreateParams service) =>
            {
                BaseResponse<UserResponseParams> res = await userService.Create(service);
                return res.Toresult();
            }).WithTags(Tag).Produces<UserResponseParams>();

            route.MapGet("User/GetAllUsers", async ([FromServices] IUserService userService) =>
            {
                BaseResponse<IEnumerable<UserResponseParams>> res = await userService.GetAllUsers();
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<IEnumerable<UserResponseParams>>>();

            route.MapGet("User/GetUsersById/{Id}", async ([FromServices] IUserService userService, int Id) =>
            {
                BaseResponse<UserResponseParams> res = await userService.GetUsersById(Id);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<UserResponseParams>>();

            route.MapPut("User/Update", async ([FromServices] IUserService userService, UserUpdateParams Params) =>
            {
                BaseResponse<UserResponseParams> res = await userService.Update(Params);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse<UserResponseParams>>();

            route.MapDelete("User/Delete", async ([FromServices] IUserService userService, int Id) =>
            {
                BaseResponse res = await userService.Delete(Id);
                return res.Toresult();
            }).WithTags(Tag).Produces<BaseResponse>();
        }
    }
}
