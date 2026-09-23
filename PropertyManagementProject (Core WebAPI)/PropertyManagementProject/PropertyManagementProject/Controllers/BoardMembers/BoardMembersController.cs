using DataAccess.DTOs.BoardMembers;
using DataAccess.Interfaces;
using DataAccess.Models.BoardMembers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementProject.Clasess.Permission;
using PropertyManagementProject.Response.Common;
using PropertyManagementProject.Response.Exceptions;

namespace PropertyManagementProject.Controllers.BoardMembers
{
    [Route("api/v1/BoardMembers")]
    [Produces("application/json")]
    [ApiController]
    public class BoardMembersController : ControllerBase
    {
        private readonly IBoardMembers _BoardMembersService;

        public BoardMembersController(IBoardMembers BoardMembersService)
        {
            _BoardMembersService = BoardMembersService;
        }

        [HttpPost("ChangeStatus")]
        [Authorize]
        [Permission("5-4-4-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusBoardMembers request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _BoardMembersService.ChangeStatus(request, userId);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("Delete")]
        [Authorize]
        [Permission("5-4-3-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteBoardMembersRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _BoardMembersService.Delete(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Insert")]
        [Authorize]
        [Permission("5-4-1-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] BoardMembers_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _BoardMembersService.Insert(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Update")]
        [Authorize]
        [Permission("5-4-2-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] BoardMembers_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _BoardMembersService.Update(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("GetAll")]
        [Authorize]
        [Permission("5-4-0-0")]
        [ProducesResponseType(typeof(BaseResponse<List<BoardMembersResponse>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<BoardMembersResponse>>> GetAll(BoardMembers_Search _Search)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                List<BoardMembersResponse>? result = await _BoardMembersService.GetAll(_Search);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("GetById")]
        [Authorize]
        [Permission("5-4-2-0")]
        [ProducesResponseType(typeof(BaseResponse<BoardMembersResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<BoardMembersResponse>>> GetById([FromBody] GetBoardMembersById requset)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                BoardMembersResponse? result = await _BoardMembersService.GetById(requset);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }
    }
}
