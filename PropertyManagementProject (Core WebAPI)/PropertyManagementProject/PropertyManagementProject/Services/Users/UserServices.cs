using DataAccess.DTOs.Login;
using DataAccess.DTOs.Users;
using DataAccess.Interfaces;
using DataAccess.Models.Users;
using Org.BouncyCastle.Asn1.Ocsp;
using PropertyManagementProject.Data;
using PropertyManagementProject.Response.Exceptions;
using PropertyManagementProject.Services.Token;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PropertyManagementProject.Services.Users
{
    public class UserServices : IUsersService
    {
        public async Task<bool> ChangeStatus(string id, bool status, string userId)
        {
            if (string.IsNullOrEmpty(id))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!int.TryParse(id, out int i))
                throw new ValidationException("مقدار شناسه صحیح نمی‌باشد.");

            if (userId == id)
                throw new ValidationException("امکان غیرفعال کردن خود وجود ندارد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ByUser(id, status, userId, 0);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت کاربر با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کاربر مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Delete(string id, string userId)
        {
            if (string.IsNullOrEmpty(id))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!int.TryParse(id, out int i))
                throw new ValidationException("شماره صحیح نمی‌باشد.");

            if (userId == id)
                throw new ValidationException("امکان غیرفعال کردن خود وجود ندارد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ByUser(id, true, userId, 1);

            if (Res == "0")
                throw new ValidationException("حذف کاربر با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کاربر مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<List<UserResponse>> GetAll()
        {
            DataTable? user = await DbConnectionFactory.DbInstance.Pr_Select_Users("0");

            if (user == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            List<UserResponse> lstUserResponse = new List<UserResponse>();

            foreach (DataRow row in user.Rows)
            {
                lstUserResponse.Add(new UserResponse
                {
                    Number = row["Number"]?.ToString() ?? string.Empty,
                    UserType = row["UserType"]?.ToString() ?? string.Empty,
                    UserGroup = row["UserGroup"]?.ToString() ?? string.Empty,
                    Name = row["Name"]?.ToString() ?? string.Empty,
                    FamilyName = row["FamilyName"]?.ToString() ?? string.Empty,
                    MobileNumber = row["MobileNumber"]?.ToString() ?? string.Empty,
                    NationalNumber = row["NationalNumber"]?.ToString() ?? string.Empty,
                    StatusText = row["StatusText"]?.ToString() ?? string.Empty
                });
            }

            return lstUserResponse;
        }

        public async Task<UserResponse> GetById(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!int.TryParse(Id, out int i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            DataTable? user = await DbConnectionFactory.DbInstance.Pr_Select_Users(Id);

            if (user == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            if (user.Rows.Count == 0)
                throw new ValidationException("کاربری یافت نشد.");

            return new UserResponse
            {
                Number = user.Rows[0]["Number"]?.ToString() ?? string.Empty,
                UserType = user.Rows[0]["UserType"]?.ToString() ?? string.Empty,
                UserGroup = user.Rows[0]["UserGroup"]?.ToString() ?? string.Empty,
                Name = user.Rows[0]["Name"]?.ToString() ?? string.Empty,
                FamilyName = user.Rows[0]["FamilyName"]?.ToString() ?? string.Empty,
                MobileNumber = user.Rows[0]["MobileNumber"]?.ToString() ?? string.Empty,
                NationalNumber = user.Rows[0]["NationalNumber"]?.ToString() ?? string.Empty,
                UserAccess = user.Rows[0]["UserAccess"]?.ToString() ?? string.Empty,
                UserName = user.Rows[0]["UserName"]?.ToString() ?? string.Empty,
                FatherName = user.Rows[0]["FatherName"]?.ToString() ?? string.Empty,
                BirthDay = user.Rows[0].Field<DateTime?>("BirthDay")
            };
        }

        public async Task<bool> Insert(UserInsert_Update dto, string userId)
        {
            if (!new[] { 0, 1 }.Contains(dto.UserGroup))
                throw new ValidationException("نوع گروه باید 0 یا 1 باشد.");

            if (string.IsNullOrEmpty(dto.UserName))
                throw new ValidationException("نام کاربری شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.Password))
                throw new ValidationException("رمز عبور شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.Name))
                throw new ValidationException("نام شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.FamilyName))
                throw new ValidationException("نام خانوادگی شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.MobileNumber))
                throw new ValidationException("شماره موبایل شخص نمی‌تواند خالی باشد.");

            if (dto.MobileNumber.StartsWith("+98"))
                dto.MobileNumber = dto.MobileNumber.Substring(3);

            if (dto.MobileNumber.StartsWith("0"))
                dto.MobileNumber = dto.MobileNumber.Substring(1);

            if(!IsValidMobile(dto.MobileNumber))
                throw new ValidationException("شماره موبایل شخص معتبر نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.NationalNumber))
                throw new ValidationException("کدملی شخص نمی‌تواند خالی باشد.");

            if (!int.TryParse(dto.NationalNumber, out int j))
                throw new ValidationException("کدملی شخص معتبر نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.FatherName))
                throw new ValidationException("نام پدر شخص نمی‌تواند خالی باشد.");

            dto.ID = "000";
            dto.Password = new PasswordService().HashPassword(dto.Password);

            if (!dto.UserType && string.IsNullOrEmpty(dto.UserAccess))
                throw new ValidationException("برای کاربر هیچ دسترسی تنظیم نشده است.");

            string[] accesses = dto.UserAccess.Split(',');

            if (accesses.Length > 0)
            {
                for (int i = 0; i < accesses.Length; i++)
                {
                    string[] parts = accesses[i]
                        .Split('-', StringSplitOptions.RemoveEmptyEntries);

                    accesses[i] = string.Join("-", parts);

                    while (parts.Length < 4)
                    {
                        accesses[i] += "-0";
                        parts = accesses[i].Split('-');
                    }
                }

                dto.UserAccess = string.Join(",", accesses);
            }


            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_Users(dto, userId);

            if (Res == "0")
                throw new ValidationException("ثبت کاربر با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کدملی کاربر مورد نظر وجود دارد.");
            else if (Res == "-3")
                throw new ValidationException("نام کاربری کاربر تکراری می‌باشد.");
            else if (Res == "-4")
                throw new ValidationException("شماره همراه تکراری می‌باشد.");
            else if (Res == "-5")
                throw new ValidationException("کاربر موردنظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Update(UserInsert_Update dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.ID))
                throw new ValidationException("مقدار شناسه کاربر نمی‌تواند خالی باشد.");

            if (!new[] { 0, 1 }.Contains(dto.UserGroup))
                throw new ValidationException("نوع گروه باید 0 یا 1 باشد.");

            if (string.IsNullOrEmpty(dto.UserName))
                throw new ValidationException("نام کاربری شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.Name))
                throw new ValidationException("نام شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.FamilyName))
                throw new ValidationException("نام خانوادگی شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.MobileNumber))
                throw new ValidationException("شماره موبایل شخص نمی‌تواند خالی باشد.");

            if (dto.MobileNumber.StartsWith("+98"))
                dto.MobileNumber = dto.MobileNumber.Substring(3);

            if (dto.MobileNumber.StartsWith("0"))
                dto.MobileNumber = dto.MobileNumber.Substring(1);

            if (!IsValidMobile(dto.MobileNumber))
                throw new ValidationException("شماره موبایل شخص معتبر نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.NationalNumber))
                throw new ValidationException("کدملی شخص نمی‌تواند خالی باشد.");

            if (!int.TryParse(dto.NationalNumber, out int j))
                throw new ValidationException("کدملی شخص معتبر نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.FatherName))
                throw new ValidationException("نام پدر شخص نمی‌تواند خالی باشد.");

            if (!string.IsNullOrEmpty(dto.Password) && dto.Password != "0")
                dto.Password = new PasswordService().HashPassword(dto.Password);

            if (!dto.UserType && string.IsNullOrEmpty(dto.UserAccess))
                throw new ValidationException("برای کاربر هیچ دسترسی تنظیم نشده است.");

            string[] accesses = dto.UserAccess.Split(',');

            if (accesses.Length > 0)
            {
                for (int i = 0; i < accesses.Length; i++)
                {
                    string[] parts = accesses[i]
                        .Split('-', StringSplitOptions.RemoveEmptyEntries);

                    accesses[i] = string.Join("-", parts);

                    while (parts.Length < 4)
                    {
                        accesses[i] += "-0";
                        parts = accesses[i].Split('-');
                    }
                }

                dto.UserAccess = string.Join(",", accesses);
            }

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_Users(dto, userId);

            if (Res == "0")
                throw new ValidationException("ویرایش کاربر با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کدملی کاربر مورد نظر وجود دارد.");
            else if (Res == "-3")
                throw new ValidationException("نام کاربری کاربر تکراری می‌باشد.");
            else if (Res == "-4")
                throw new ValidationException("شماره همراه تکراری می‌باشد.");
            else if (Res == "-5")
                throw new ValidationException("کاربر موردنظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public static bool IsValidMobile(string? mobile)
        {
            if (string.IsNullOrEmpty(mobile))
                return false;

            mobile = mobile.Trim();

            return Regex.IsMatch(mobile, @"^(?:\+98|98|0)?9\d{9}$");
        }
    }
}
