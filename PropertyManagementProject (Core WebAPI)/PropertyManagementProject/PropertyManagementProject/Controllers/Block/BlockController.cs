using DataAccess.DTOs.Block;
using DataAccess.Interfaces;
using DataAccess.Models.Block;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementProject.Clasess.Permission;
using PropertyManagementProject.Response.Common;
using PropertyManagementProject.Response.Exceptions;
using PropertyManagementProject.Services.TownShip;

namespace PropertyManagementProject.Controllers.Block
{
    [Route("api/v1/Block")]
    [Produces("application/json")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly IBlockServices _BlockService;

        public BlockController(IBlockServices BlockService)
        {
            _BlockService = BlockService;
        }

        [HttpPost("ChangeStatus")]
        [Authorize]
        [Permission("5-2-4-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusBlock request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _BlockService.ChangeStatus(request.Number, request.Status, userId);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("Delete")]
        [Authorize]
        [Permission("5-2-3-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteBlockRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                if (string.IsNullOrEmpty(request.Number))
                    throw new BadRequestException("شماره شهرک معتبر نیست.");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _BlockService.Delete(request.Number, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Insert")]
        [Authorize]
        [Permission("5-2-1-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] Block_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _BlockService.Insert(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Update")]
        [Authorize]
        [Permission("5-2-2-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] Block_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _BlockService.Update(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("GetAll")]
        [Authorize]
        [Permission("5-2-0-0")]
        [ProducesResponseType(typeof(BaseResponse<List<BlockResponse>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<BlockResponse>>> GetAll(Block_Search _Search)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                List<BlockResponse>? result = await _BlockService.GetAll(_Search);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("GetById")]
        [Authorize]
        [Permission("5-2-2-0")]
        [ProducesResponseType(typeof(BaseResponse<BlockResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<BlockResponse>>> GetById([FromBody] GetBlocksById requset)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                BlockResponse? result = await _BlockService.GetById(requset.BlockNumber);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

    }
}
