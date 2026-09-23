using ClipShare_Youtube_.Extensions;
using ClipShare_Youtube_.Utility;
using ClipShare_Youtube_.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClipShare_Youtube_.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            Login_VM login = new Login_VM
            {
                ReturnUrl = returnUrl
            };

            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login_VM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            login.ReturnUrl ??= Url.Content("~/");

            DataTable table = await DBExcueteCommand.DbInstance.Pr_Select_Login(login.UserName, login.Password);

            if (table == null || table.Rows.Count == 0)
            {
                _logger.LogError("Invalid UserName Or Paaword.");
                ModelState.AddModelError(string.Empty, "Invalid UserName Or Paaword.");
                return View(login);
            }

            await HandleLoginAsync(table);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register_vm register)
        {
            if (ModelState.IsValid)
            {
                if (!register.Password.Equals(register.ConfirmPassword))
                {
                    _logger.LogError("Password And ConfirmPassword Does not match.");
                    ModelState.AddModelError("ConfirmPassword", "Password And ConfirmPassword Does not match.");
                    return View(register);
                }

                string res = await DBExcueteCommand.DbInstance.Pr_InsUp_SignUp(register.Name, register.Password, false);

                if (res == "-1")
                {
                    _logger.LogError("UserName Or Password Use Another User.");
                    ModelState.AddModelError("Exists", "UserName Or Password Use Another User.");
                    return View(register);
                }
                else if (res == "0" || res == "")
                {
                    _logger.LogError("Create User Error.");
                    ModelState.AddModelError("Error", "Create User Error.");
                    return View(register);
                }
                else
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("UserName", typeof(string));
                    dataTable.Columns.Add("IsAdmin", typeof(bool));
                    dataTable.Columns.Add("Id", typeof(string));

                    DataRow row = dataTable.NewRow();
                    row["UserName"] = register.Name;
                    row["IsAdmin"] = register.IsAdmin;
                    row["Id"] = res;

                    dataTable.Rows.Add(row);

                    await HandleLoginAsync(dataTable);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(register);
        }

        private async Task HandleLoginAsync(DataTable dt)
        {
            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(ClaimTypes.Name, dt.Rows[0]["UserName"]?.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, Convert.ToBoolean(dt.Rows[0]["IsAdmin"]) ? "Admin" : "User"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, dt.Rows[0]["Id"]?.ToString()));

            SD.UserId = dt.Rows[0]["Id"]?.ToString();
            SD.UserRole = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]) ? "Admin" : "User";
            SD.UserName = dt.Rows[0]["UserName"]?.ToString();

            ClaimsPrincipal pr = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, pr);
        }
    }
}
