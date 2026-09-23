using DataAccess.DTOs.OfficialExperts;
using DataAccess.Interfaces;
using DataAccess.Models.OfficialExperts;
using PropertyManagementProject.Data;
using PropertyManagementProject.Response.Exceptions;
using System.Data;
using System.Text.RegularExpressions;

namespace PropertyManagementProject.Services.OfficialExperts
{
    public class OfficialExpertsServices : IOfficialExperts
    {
        public async Task<bool> ChangeStatus(ChangeStatusOfficialExperts changeStatus, string UserId)
        {
            if (string.IsNullOrEmpty(changeStatus.Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(changeStatus.Number, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForOfficialExperts(changeStatus.Number, changeStatus.Status, UserId, 0);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت کارشناس با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کارشناس مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Delete(DeleteOfficialExpertsRequest deleteOfficialExperts, string userId)
        {
            if (string.IsNullOrEmpty(deleteOfficialExperts.Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(deleteOfficialExperts.Number, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForOfficialExperts(deleteOfficialExperts.Number, true, userId, 1);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت کارشناس با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کارشناس مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<List<OfficialExpertsResponse>> GetAll(OfficialExperts_Search _Search)
        {
            if (!new[] { -1, 1, 2 }.Contains(_Search.Type))
                throw new ValidationException("مقدار وارد شده برای نوع جستجو معتبر نمی‌باشد.");

            if (!new[] { 0, 1, 2 }.Contains(_Search.TypeStatus))
                throw new ValidationException("نوع جستجو وضعیت معتبر نمی‌باشد.");

            if (_Search.Value == null)
                throw new ValidationException("مقدار عبارت جستجو شده نامعتبر می‌باشد.");

            if (!int.TryParse(_Search.Page, out int i))
                throw new ValidationException("مقدار وارد شده صفحه نامعتبر می‌باشد.");

            if (!int.TryParse(_Search.OffSet, out int j))
                throw new ValidationException("مقدار وارد شده تعداد نامعتبر می‌باشد.");

            if (Convert.ToInt32(_Search.Page) < 1)
                throw new ValidationException("مقدار وارد شده صفحه باید حداقل 1 ‌باشد.");

            if (Convert.ToInt32(_Search.OffSet) < 10)
                throw new ValidationException("مقدار وارد شده تعداد باید حداقل 10 ‌باشد.");

            DataTable? OfficialExperts = await DbConnectionFactory.DbInstance.Pr_Select_OfficialExperts("0", _Search.Type.ToString(), _Search.TypeStatus.ToString(),
                _Search.Value, _Search.Page, _Search.OffSet);

            if (OfficialExperts == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            List<OfficialExpertsResponse> lstOfficialExpertsResponse = new List<OfficialExpertsResponse>();

            foreach (DataRow row in OfficialExperts.Rows)
            {
                lstOfficialExpertsResponse.Add(new OfficialExpertsResponse
                {
                    OfficialExpertsNumber = row["OfficialExpertsNumber"]?.ToString() ?? string.Empty,
                    Name_Family = row["Name_Family"]?.ToString() ?? string.Empty,
                    Name = row["Name"]?.ToString() ?? string.Empty,
                    Family = row["FamilyName"]?.ToString() ?? string.Empty,
                    ExpertLicenseNumber = row["ExpertLicenseNumber"]?.ToString() ?? string.Empty,
                    NationalNumber = row["NationalNumber"]?.ToString() ?? string.Empty,
                    MobileNumber = row["MobileNumber"]?.ToString() ?? string.Empty,
                    StatusText = row["StatusText"]?.ToString() ?? string.Empty,
                    TotalCount = row["TotalCount"]?.ToString() ?? string.Empty
                });
            }

            return lstOfficialExpertsResponse;
        }

        public async Task<OfficialExpertsResponse> GetById(GetOfficialExpertsById OfficialExpertsById)
        {
            if (string.IsNullOrEmpty(OfficialExpertsById.OfficialExpertsNumber))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(OfficialExpertsById.OfficialExpertsNumber, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            DataTable? BoardMembers = await DbConnectionFactory.DbInstance.Pr_Select_OfficialExperts(OfficialExpertsById.OfficialExpertsNumber);

            if (BoardMembers == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            if (BoardMembers.Rows.Count == 0)
                throw new ValidationException("کارشناسی یافت نشد.");

            return new OfficialExpertsResponse
            {
                OfficialExpertsNumber = BoardMembers.Rows[0]["OfficialExpertsNumber"]?.ToString() ?? string.Empty,
                Name = BoardMembers.Rows[0]["Name"]?.ToString() ?? string.Empty,
                Family = BoardMembers.Rows[0]["FamilyName"]?.ToString() ?? string.Empty,
                ExpertLicenseNumber = BoardMembers.Rows[0]["ExpertLicenseNumber"]?.ToString() ?? string.Empty,
                NationalNumber = BoardMembers.Rows[0]["NationalNumber"]?.ToString() ?? string.Empty,
                MobileNumber = BoardMembers.Rows[0]["MobileNumber"]?.ToString() ?? string.Empty,
                StatusText = BoardMembers.Rows[0]["StatusText"]?.ToString() ?? string.Empty,
                TotalCount = "1"
            };
        }

        public async Task<bool> Insert(OfficialExperts_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ValidationException("نام کارشناس نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.FamilyName))
                throw new ValidationException("نام خانوادگی کارشناس نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.MobileNumber))
                throw new ValidationException("شماره موبایل کارشناس نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.ExpertLicenseNumber))
                throw new ValidationException("شماره رسمی کارشناس نمی‌تواند خالی باشد.");

            if (dto.MobileNumber.StartsWith("+98"))
                dto.MobileNumber = dto.MobileNumber.Substring(3);

            if (dto.MobileNumber.StartsWith("0"))
                dto.MobileNumber = dto.MobileNumber.Substring(1);

            if (!IsValidMobile(dto.MobileNumber))
                throw new ValidationException("شماره موبایل کارشناس معتبر نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.NationalNumber))
                throw new ValidationException("کدملی کارشناس نمی‌تواند خالی باشد.");

            if (!int.TryParse(dto.NationalNumber, out int j))
                throw new ValidationException("کدملی کارشناس معتبر نمی‌باشد.");

            dto.OfficialExpertsNumber = "000";

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_OfficialExperts(dto, userId);

            if (Res == "0")
                throw new ValidationException("ثبت کارشناس با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("شخص درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کدملی کارشناس مورد نظر وجود دارد.");
            else if (Res == "-4")
                throw new ValidationException("شماره همراه تکراری می‌باشد.");
            else if (Res == "-5")
                throw new ValidationException("کارشناس موردنظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Update(OfficialExperts_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.OfficialExpertsNumber))
                throw new ValidationException("مقدار شناسه کارشناس نمی‌تواند خالی باشد.");

            if (!Guid.TryParse(dto.OfficialExpertsNumber, out Guid i))
                throw new ValidationException("مقدار شناسه کارشناس صحیح نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.Name))
                throw new ValidationException("نام کارشناس نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.FamilyName))
                throw new ValidationException("نام خانوادگی کارشناس نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.MobileNumber))
                throw new ValidationException("شماره موبایل کارشناس نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.ExpertLicenseNumber))
                throw new ValidationException("شماره رسمی کارشناس نمی‌تواند خالی باشد.");

            if (dto.MobileNumber.StartsWith("+98"))
                dto.MobileNumber = dto.MobileNumber.Substring(3);

            if (dto.MobileNumber.StartsWith("0"))
                dto.MobileNumber = dto.MobileNumber.Substring(1);

            if (!IsValidMobile(dto.MobileNumber))
                throw new ValidationException("شماره موبایل کارشناس معتبر نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.NationalNumber))
                throw new ValidationException("کدملی کارشناس نمی‌تواند خالی باشد.");

            if (!int.TryParse(dto.NationalNumber, out int j))
                throw new ValidationException("کدملی کارشناس معتبر نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_OfficialExperts(dto, userId);

            if (Res == "0")
                throw new ValidationException("ویرایش کارشناس با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("شخص درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کدملی کارشناس مورد نظر وجود دارد.");
            else if (Res == "-4")
                throw new ValidationException("شماره همراه تکراری می‌باشد.");
            else if (Res == "-5")
                throw new ValidationException("کارشناس موردنظر یافت نشد.");
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
