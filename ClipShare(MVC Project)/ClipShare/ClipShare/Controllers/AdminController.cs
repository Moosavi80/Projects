using ClipShare_Youtube_.Extensions;
using ClipShare_Youtube_.ViewModels;
using ClipShare_Youtube_.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ClipShare_Youtube_.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            DataTable res = await DBExcueteCommand.DbInstance.Pr_Select_Category();

            if (res == null)
                return Json(new ApiResponse(500, "", "Data Is Null", null));

            if (res != null && res.Rows.Count == 0)
                return Json(new ApiResponse(404, "", "Data Is Empty", null));

            List<Category_vm> category_s = new List<Category_vm>();

            foreach (DataRow item in res.Rows)
            {
                Category_vm category = new Category_vm();

                category.Name = item["Name"].ToString();
                category.Id = item["Id"].ToString();

                category_s.Add(category);
            }

            return Json(new ApiResponse(200, "", "", category_s));
        }

        [HttpPost]
        public async Task<IActionResult> AddEditCategory(Category_vm model)
        {
            if (ModelState.IsValid)
            {
                string res = await DBExcueteCommand.DbInstance.Pr_InsUp_Category(model.Id, model.Name);

                if (string.IsNullOrEmpty(res))
                    return Json(new ApiResponse(400, "", "Create Or Update Not Complete."));

                return Json(new ApiResponse(200, "", "", model));
            }

            return Json(new ApiResponse(400, "", "Model Is not Valid."));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string Id)
        {
            string res = await DBExcueteCommand.DbInstance.Pr_Del_Category(Id);

            if (string.IsNullOrEmpty(res) && res == "0")
                return Json(new ApiResponse(404, "", "Category Is Not Exists."));

            return Json(new ApiResponse(200, "Deleted", "Category Is Deleted Succssfuly."));
        }
    }
}
