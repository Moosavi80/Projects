using ClipShare_Youtube_.Extensions;
using ClipShare_Youtube_.Utility;
using ClipShare_Youtube_.ViewModels.Account;
using ClipShare_Youtube_.ViewModels.Channel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ClipShare_Youtube_.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ChannelController : Controller
    {
        public async Task<IActionResult> Index()
        {
            Channel_vm vms = new Channel_vm();

            DataTable data = await DBExcueteCommand.DbInstance.Pr_Select_Channel(SD.UserId);

            if (data != null && data.Rows.Count > 0)
            {
                vms.Name = data.Rows[0]["Name"].ToString();
                vms.About = data.Rows[0]["About"].ToString();
                vms.ChannelId = data.Rows[0]["Id"].ToString();
            }

            return View(vms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Channel_vm channel)
        {
            if (ModelState.IsValid)
            {
                string res = await DBExcueteCommand.DbInstance.Pr_InsUp_Channel(channel.Name, channel.About, SD.UserId);

                if (res == "-1")
                {
                    ModelState.AddModelError("Create", "User Is Not Premision For Create Channel.");
                    return View(channel);
                }
                else if (res == "0" || res == "")
                {
                    ModelState.AddModelError("Error", "Create Channel Error.");
                    return View(channel);
                }
                else if (res == "-2")
                {
                    ModelState.AddModelError("Error", "This Channel Before Created.");
                    return View(channel);
                }
                else
                    return RedirectToAction("Index");
            }

            return View(channel);
        }
    }
}
