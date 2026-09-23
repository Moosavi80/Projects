using DataAccess.DTOs.Plot;
using DataAccess.Interfaces;
using DataAccess.Models.Plot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementProject.Clasess.Permission;
using PropertyManagementProject.Response.Common;
using PropertyManagementProject.Response.Exceptions;

namespace PropertyManagementProject.Controllers.Plot
{
    [Route("api/v1/Plot")]
    [Produces("application/json")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly IPlotServices _PlotService;

        public PlotController(IPlotServices PlotService)
        {
            _PlotService = PlotService;
        }

        [HttpPost("ChangeStatus")]
        [Authorize]
        [Permission("5-3-4-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusPlot request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _PlotService.ChangeStatus(request, userId);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("Delete")]
        [Authorize]
        [Permission("5-3-3-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeletePlotRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _PlotService.Delete(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Insert")]
        [Authorize]
        [Permission("5-3-1-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] Plot_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _PlotService.Insert(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Update")]
        [Authorize]
        [Permission("5-3-2-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] Plot_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _PlotService.Update(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("GetAll")]
        [Authorize]
        [Permission("5-3-0-0")]
        [ProducesResponseType(typeof(BaseResponse<List<PlotResponse>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<PlotResponse>>> GetAll(Plot_Search _Search)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                List<PlotResponse>? result = await _PlotService.GetAll(_Search);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("GetById")]
        [Authorize]
        [Permission("5-3-2-0")]
        [ProducesResponseType(typeof(BaseResponse<PlotResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<PlotResponse>>> GetById([FromBody] GetPlotsById requset)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                PlotResponse? result = await _PlotService.GetById(requset);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpGet("GetLandUseType")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<List<LandUseTypeResponse>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<LandUseTypeResponse>>> GetLandUseType()
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                List<LandUseTypeResponse>? result = await _PlotService.GetLandUseType();

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }
    }
}
