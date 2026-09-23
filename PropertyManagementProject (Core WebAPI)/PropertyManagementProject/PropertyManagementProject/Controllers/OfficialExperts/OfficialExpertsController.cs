using DataAccess.DTOs.OfficialExperts;
using DataAccess.Interfaces;
using DataAccess.Models.OfficialExperts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementProject.Clasess.Permission;
using PropertyManagementProject.Response.Common;
using PropertyManagementProject.Response.Exceptions;

namespace PropertyManagementProject.Controllers.OfficialExperts
{
    [Route("api/v1/OfficialExperts")]
    [Produces("application/json")]
    [ApiController]
    public class OfficialExpertsController : ControllerBase
    {
        private readonly IOfficialExperts _OfficialExpertsService;

        public OfficialExpertsController(IOfficialExperts OfficialExpertsService)
        {
            _OfficialExpertsService = OfficialExpertsService;
        }

        [HttpPost("ChangeStatus")]
        [Authorize]
        [Permission("5-5-4-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusOfficialExperts request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _OfficialExpertsService.ChangeStatus(request, userId);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("Delete")]
        [Authorize]
        [Permission("5-5-3-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteOfficialExpertsRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _OfficialExpertsService.Delete(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Insert")]
        [Authorize]
        [Permission("5-5-1-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] OfficialExperts_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _OfficialExpertsService.Insert(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("Update")]
        [Authorize]
        [Permission("5-5-2-0")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] OfficialExperts_InsUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                bool result = await _OfficialExpertsService.Update(request, userId);

                return Ok(result);
            }
            catch { throw; }
        }

        [HttpPost("GetAll")]
        [Authorize]
        [Permission("5-5-0-0")]
        [ProducesResponseType(typeof(BaseResponse<List<OfficialExpertsResponse>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<OfficialExpertsResponse>>> GetAll(OfficialExperts_Search _Search)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                List<OfficialExpertsResponse>? result = await _OfficialExpertsService.GetAll(_Search);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }

        [HttpPost("GetById")]
        [Authorize]
        [Permission("5-5-2-0")]
        [ProducesResponseType(typeof(BaseResponse<OfficialExpertsResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<OfficialExpertsResponse>>> GetById([FromBody] GetOfficialExpertsById requset)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new BadRequestException("داده‌های ورودی نامعتبر است");

                string userId = User.FindFirst("UI")!.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new ValidationException("کاربر احراز هویت نشده است.");

                OfficialExpertsResponse? result = await _OfficialExpertsService.GetById(requset);

                return Ok(ApiResponse.Success(result));
            }
            catch { throw; }
        }
    }
}
