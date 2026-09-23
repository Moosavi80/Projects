using ClipShare_Youtube_.Extensions;
using ClipShare_Youtube_.Utility;
using ClipShare_Youtube_.ViewModels.Channel;
using ClipShare_Youtube_.ViewModels.Video;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClipShare_Youtube_.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VideoController : Controller
    {
        private readonly IConfiguration _configuration;

        public VideoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> CreateEditVideo(int Id)
        {
            bool IsAccess = await DBExcueteCommand.DbInstance.CheckCreateChannel(SD.UserId);

            if (!IsAccess)
            {
                ModelState.AddModelError("Error", "No Channel For User. Please Create Channel.");
                return RedirectToAction("Index", "Channel");
            }

            AddEditVideo_vm video_Vm = new AddEditVideo_vm();
            video_Vm.ImageContentTypes = string.Join(",", AcceptContentTypes("Image"));
            video_Vm.VideoContentTypes = string.Join(",", AcceptContentTypes("Video"));
            video_Vm.CategoryDropDown = await GetCategoryDropDownAsync();

            if (Id == 0) { }

            return View(video_Vm);
        }


        #region Private Method

        public async Task<IEnumerable<SelectListItem>> GetCategoryDropDownAsync()
        {
            DataTable dtlist = await DBExcueteCommand.DbInstance.Pr_Select_Category();

            if (dtlist == null || dtlist.Rows.Count == 0)
                return new List<SelectListItem> { new("", "") };

            return dtlist.AsEnumerable().Select
            (
                cat => new SelectListItem
                {
                    Text = cat.Field<string>("Name"),
                    Value = cat.Field<int>("Id").ToString()
                }
            ).ToList();
        }

        private string[] AcceptContentTypes(string contentType)
        {
            if (contentType == "Image")
                return _configuration.GetSection("FileUpload:ImageContentTypes").Get<string[]>();
            else if (contentType == "Video")
                return _configuration.GetSection("FileUpload:VideoContentTypes").Get<string[]>();
            else
                return System.Array.Empty<string>();
        }
        #endregion
    }
}
