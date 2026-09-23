using DataAccess.DTOs.BoardMembers;
using DataAccess.Interfaces;
using DataAccess.Models.BoardMembers;
using PropertyManagementProject.Data;
using PropertyManagementProject.Response.Exceptions;
using PropertyManagementProject.Services.Token;
using System.Data;
using System.Text.RegularExpressions;

namespace PropertyManagementProject.Services.BoardMembers
{
    public class BoardMembersServices : IBoardMembers
    {
        public async Task<bool> ChangeStatus(ChangeStatusBoardMembers changeStatus, string UserId)
        {
            if (string.IsNullOrEmpty(changeStatus.Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(changeStatus.Number, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForBoardMembers(changeStatus.Number, changeStatus.Status, UserId, 0);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت شخص با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("شخص مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Delete(DeleteBoardMembersRequest deleteBoardMembers, string userId)
        {
            if (string.IsNullOrEmpty(deleteBoardMembers.Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(deleteBoardMembers.Number, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForBoardMembers(deleteBoardMembers.Number, true, userId, 1);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت شخص با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("شخص مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<List<BoardMembersResponse>> GetAll(BoardMembers_Search _Search)
        {
            if (!new[] { -1, 1 }.Contains(_Search.Type))
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

            DataTable? BoardMembers = await DbConnectionFactory.DbInstance.Pr_Select_BoardMembers("0", _Search.Type.ToString(), _Search.TypeStatus.ToString(),
                _Search.Value, _Search.Page, _Search.OffSet);

            if (BoardMembers == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            List<BoardMembersResponse> lstBoardMembersResponse = new List<BoardMembersResponse>();

            foreach (DataRow row in BoardMembers.Rows)
            {
                lstBoardMembersResponse.Add(new BoardMembersResponse
                {
                    BoardMembersNumber = row["BoardMembersNumber"]?.ToString() ?? string.Empty,
                    Name = row["Name"]?.ToString() ?? string.Empty,
                    FamilyName = row["FamilyName"]?.ToString() ?? string.Empty,
                    BirthCertificateNumber = row["BirthCertificateNumber"]?.ToString() ?? string.Empty,
                    NationalNumber = row["NationalNumber"]?.ToString() ?? string.Empty,
                    MobileNumber = row["MobileNumber"]?.ToString() ?? string.Empty,
                    StatusText = row["StatusText"]?.ToString() ?? string.Empty,
                    TotalCount = row["TotalCount"]?.ToString() ?? string.Empty
                });
            }

            return lstBoardMembersResponse;
        }

        public async Task<BoardMembersResponse> GetById(GetBoardMembersById BoardMembersById)
        {
            if (string.IsNullOrEmpty(BoardMembersById.BoardMembersNumber))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(BoardMembersById.BoardMembersNumber, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            DataTable? BoardMembers = await DbConnectionFactory.DbInstance.Pr_Select_BoardMembers(BoardMembersById.BoardMembersNumber);

            if (BoardMembers == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            if (BoardMembers.Rows.Count == 0)
                throw new ValidationException("شخصی یافت نشد.");

            return new BoardMembersResponse
            {
                BoardMembersNumber = BoardMembers.Rows[0]["BoardMembersNumber"]?.ToString() ?? string.Empty,
                Name = BoardMembers.Rows[0]["Name"]?.ToString() ?? string.Empty,
                FamilyName = BoardMembers.Rows[0]["FamilyName"]?.ToString() ?? string.Empty,
                BirthCertificateNumber = BoardMembers.Rows[0]["BirthCertificateNumber"]?.ToString() ?? string.Empty,
                NationalNumber = BoardMembers.Rows[0]["NationalNumber"]?.ToString() ?? string.Empty,
                MobileNumber = BoardMembers.Rows[0]["MobileNumber"]?.ToString() ?? string.Empty,
                FatherName = BoardMembers.Rows[0]["FatherName"]?.ToString() ?? string.Empty,
                BirthDay = BoardMembers.Rows[0].Field<DateTime?>("BirthDay"),
                StatusText = BoardMembers.Rows[0]["StatusText"]?.ToString() ?? string.Empty,
                TotalCount = "1"
            };
        }

        public async Task<bool> Insert(BoardMembers_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ValidationException("نام شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.FamilyName))
                throw new ValidationException("نام خانوادگی شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.MobileNumber))
                throw new ValidationException("شماره موبایل شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.BirthCertificateNumber))
                throw new ValidationException("شماره شناسنامه شخص نمی‌تواند خالی باشد.");

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

            dto.BoardMembersNumber = "000";

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_BoardMembers(dto, userId);

            if (Res == "0")
                throw new ValidationException("ثبت شخص با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("شخص درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کدملی شخص مورد نظر وجود دارد.");
            else if (Res == "-4")
                throw new ValidationException("شماره همراه تکراری می‌باشد.");
            else if (Res == "-5")
                throw new ValidationException("شخص موردنظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Update(BoardMembers_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.BoardMembersNumber))
                throw new ValidationException("مقدار شناسه شخص نمی‌تواند خالی باشد.");

            if (!Guid.TryParse(dto.BoardMembersNumber, out Guid i))
                throw new ValidationException("مقدار شناسه شخص صحیح نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.Name))
                throw new ValidationException("نام شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.FamilyName))
                throw new ValidationException("نام خانوادگی شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.MobileNumber))
                throw new ValidationException("شماره موبایل شخص نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.BirthCertificateNumber))
                throw new ValidationException("شماره شناسنامه شخص نمی‌تواند خالی باشد.");

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

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_BoardMembers(dto, userId);

            if (Res == "0")
                throw new ValidationException("ویرایش شخص با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("شخص درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("کدملی شخص مورد نظر وجود دارد.");
            else if (Res == "-4")
                throw new ValidationException("شماره همراه تکراری می‌باشد.");
            else if (Res == "-5")
                throw new ValidationException("شخص موردنظر یافت نشد.");
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
