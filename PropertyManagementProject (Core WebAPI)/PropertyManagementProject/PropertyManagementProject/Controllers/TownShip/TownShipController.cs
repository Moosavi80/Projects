using DataAccess.DTOs.TownShip;
using DataAccess.Interfaces;
using DataAccess.Models.TownShip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementProject.Clasess.Permission;
using PropertyManagementProject.Response.Common;
using PropertyManagementProject.Response.Exceptions;

namespace PropertyManagementProject.Controllers.TownShip
{
    [Route("api/v1/TownShip")]
    [Produces("application/json")]
    [ApiController]
    public class TownShipController : ControllerBase
    {
        private readonly ITownShipServices _TownShipService;

        public TownShipController(ITownShipServices TownShipService)
        {
            _TownShipService = TownShipService;
        }

        [HttpPost("ChangeStatus")]
        [Authorize]
        [Permission("5-1-4-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusTownShip request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _TownShipService.ChangeStatus(request.Number, request.Status, userId);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("Delete")]
        [Authorize]
        [Permission("5-1-3-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteTownShipRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _TownShipService.Delete(request.Number, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Insert")]
        [Authorize]
        [Permission("5-1-1-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] TownShip_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _TownShipService.Insert(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Update")]
        [Authorize]
        [Permission("5-1-2-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] TownShip_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _TownShipService.Update(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpGet("GetAll")]
        [Authorize]
        [Permission("5-1-0-0")]
        [ProducesResponseType(typeof(BaseResponse<List<TownShipResponse>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<TownShipResponse>>> GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                List<TownShipResponse>? result = await _TownShipService.GetAll();

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("GetById")]
        [Authorize]
        [Permission("5-1-2-0")]
        [ProducesResponseType(typeof(BaseResponse<TownShipResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<TownShipResponse>>> GetById([FromBody] GetTownShipById requset)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                TownShipResponse? result = await _TownShipService.GetById(requset.Number);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("TownShipSearch")]
        [Authorize]
        [Permission("5-1-0-0")]
        [ProducesResponseType(typeof(BaseResponse<List<TownShipResponse>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<TownShipResponse>>> TownShipSearch([FromBody] TownShip_Search requset)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                List<TownShipResponse>? result = await _TownShipService.TownShipSearch(requset);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }
    }
}
