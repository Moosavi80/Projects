using DataAccess.DTOs.TownShip;
using DataAccess.Interfaces;
using DataAccess.Models.TownShip;
using PropertyManagementProject.Data;
using PropertyManagementProject.Response.Exceptions;
using PropertyManagementProject.Services.Token;
using System.Data;

namespace PropertyManagementProject.Services.TownShip
{
    public class TownShipService : ITownShipServices
    {
        public async Task<bool> ChangeStatus(string Number, bool Status, string UserId)
        {
            if (string.IsNullOrEmpty(Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(Number, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForTownShip(Number, Status, UserId, 0);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت شهرک با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("شهرک مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Delete(string Number, string userId)
        {
            if (string.IsNullOrEmpty(Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(Number, out Guid i))
                throw new ValidationException("شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForTownShip(Number, true, userId, 1);

            if (Res == "0")
                throw new ValidationException("حذف شهرک با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("شهرک مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<List<TownShipResponse>> GetAll()
        {
            DataTable? township = await DbConnectionFactory.DbInstance.Pr_Select_TownShip("0");

            if (township == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            List<TownShipResponse> lstUserResponse = new List<TownShipResponse>();

            foreach (DataRow row in township.Rows)
            {
                lstUserResponse.Add(new TownShipResponse
                {
                    Number = row["Number"]?.ToString() ?? string.Empty,
                    Name = row["Name"]?.ToString() ?? string.Empty,
                    StatusText = row["StatusText"]?.ToString() ?? string.Empty
                });
            }

            return lstUserResponse;
        }

        public async Task<TownShipResponse> GetById(string Number)
        {
            if (string.IsNullOrEmpty(Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(Number, out Guid i))
                throw new ValidationException("شماره صحیح نمی‌باشد.");

            DataTable? township = await DbConnectionFactory.DbInstance.Pr_Select_TownShip(Number);

            if (township == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            if (township.Rows.Count == 0)
                throw new ValidationException("شهرکی یافت نشد.");

            return new TownShipResponse
            {
                Number = township.Rows[0]["Number"]?.ToString() ?? string.Empty,
                Name = township.Rows[0]["Name"]?.ToString() ?? string.Empty,
                StatusText = township.Rows[0]["StatusText"]?.ToString() ?? string.Empty
            };
        }

        public async Task<bool> Insert(TownShip_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ValidationException("نام شهرک نمی‌تواند خالی باشد.");

            dto.Number = "000";

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_TownShip(dto, userId);

            if (Res == "0")
                throw new ValidationException("ثبت شهرک با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("نام شهرک قبلا ثبت شده است.");
            else if (Res == "-3")
                throw new ValidationException("شناسه شهرک یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<List<TownShipResponse>> TownShipSearch(TownShip_Search _Search)
        {
            if (!new[] { 0, 1 }.Contains(_Search.Type))
                throw new ValidationException("نوع جستجو باید 0 یا 1 باشد.");

            if (_Search.Value == null)
                throw new ValidationException("مقدار جستجو نامعتبر می‌باشد.");

            DataTable? township = await DbConnectionFactory.DbInstance.Pr_Select_TownShip("0", _Search.Type.ToString(), _Search.Value);

            if (township == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            List<TownShipResponse> lstUserResponse = new List<TownShipResponse>();

            foreach (DataRow row in township.Rows)
            {
                lstUserResponse.Add(new TownShipResponse
                {
                    Number = row["Number"]?.ToString() ?? string.Empty,
                    Name = row["Name"]?.ToString() ?? string.Empty,
                    StatusText = row["StatusText"]?.ToString() ?? string.Empty
                });
            }

            return lstUserResponse;
        }

        public async Task<bool> Update(TownShip_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.Number))
                throw new ValidationException("مقدار شماره شهرک نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.Name))
                throw new ValidationException("نام شهرک نمی‌تواند خالی باشد.");

            if (!Guid.TryParse(dto.Number, out Guid i))
                throw new ValidationException("شماره شهرک صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_TownShip(dto, userId);

            if (Res == "0")
                throw new ValidationException("ویرایش شهرک با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("نام شهرک قبلا ثبت شده است.");
            else if (Res == "-3")
                throw new ValidationException("شناسه شهرک یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }
    }
}
