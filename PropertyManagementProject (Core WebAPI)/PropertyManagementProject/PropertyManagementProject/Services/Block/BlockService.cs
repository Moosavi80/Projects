using DataAccess.DTOs.Block;
using DataAccess.Interfaces;
using DataAccess.Models.Block;
using DataAccess.Models.TownShip;
using PropertyManagementProject.Data;
using PropertyManagementProject.Response.Exceptions;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PropertyManagementProject.Services.Block
{
    public class BlockService : IBlockServices
    {
        public async Task<bool> ChangeStatus(string Number, bool Status, string UserId)
        {
            if (string.IsNullOrEmpty(Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(Number, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForBlocks(Number, Status, UserId, 0);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت بلوک با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("بلوک مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Delete(string Number, string userId)
        {
            if (string.IsNullOrEmpty(Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(Number, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForBlocks(Number, true, userId, 1);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت بلوک با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("بلوک مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<List<BlockResponse>> GetAll(Block_Search _Search)
        {
            if (!new[] { 0, 1, 2, -1 }.Contains(_Search.Type))
                throw new ValidationException("نوع جستجو باید (\u200E-1, 0, 1, 2\u200E) باشد.");

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

            DataTable? Blocks = await DbConnectionFactory.DbInstance.Pr_Select_Blocks("0", _Search.Type.ToString(), _Search.TypeStatus.ToString(), _Search.Value, _Search.Page, _Search.OffSet);

            if (Blocks == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            List<BlockResponse> lstBlocksResponse = new List<BlockResponse>();

            foreach (DataRow row in Blocks.Rows)
            {
                lstBlocksResponse.Add(new BlockResponse
                {
                    BlockNumber = row["BlockNumber"]?.ToString() ?? string.Empty,
                    BlockName = row["BlockName"]?.ToString() ?? string.Empty,
                    TownShipName = row["TownShipName"]?.ToString() ?? string.Empty,
                    StatusText = row["StatusText"]?.ToString() ?? string.Empty,
                    TotalCount = row["TotalCount"]?.ToString() ?? string.Empty
                });
            }

            return lstBlocksResponse;
        }

        public async Task<BlockResponse> GetById(string BlockNumber)
        {
            if (string.IsNullOrEmpty(BlockNumber))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(BlockNumber, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            DataTable? Blocks = await DbConnectionFactory.DbInstance.Pr_Select_Blocks(BlockNumber);

            if (Blocks == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            if (Blocks.Rows.Count == 0)
                throw new ValidationException("بلوکی یافت نشد.");

            return new BlockResponse
            {
                BlockNumber = Blocks.Rows[0]["BlockNumber"]?.ToString() ?? string.Empty,
                BlockName = Blocks.Rows[0]["BlockName"]?.ToString() ?? string.Empty,
                TownShipName = Blocks.Rows[0]["TownShipName"]?.ToString() ?? string.Empty,
                StatusText = Blocks.Rows[0]["StatusText"]?.ToString() ?? string.Empty,
                TotalCount = "1"
            };
        }

        public async Task<bool> Insert(Block_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.BlockName))
                throw new ValidationException("نام بلوک نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.TownShipNumber))
                throw new ValidationException("مقدار شماره شهرک نمی‌تواند خالی باشد.");

            if (!Guid.TryParse(dto.TownShipNumber, out Guid i))
                throw new ValidationException("مقدار شماره شهرک صحیح نمی‌باشد.");

            dto.BlockNumber = "000";

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_Blocks(dto, userId);

            if (Res == "0")
                throw new ValidationException("ثبت بلوک با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("نام بلوک قبلا ثبت شده است.");
            else if (Res == "-3")
                throw new ValidationException("شناسه شهرک یافت نشد.");
            else if (Res == "-4")
                throw new ValidationException("شناسه بلوک یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Update(Block_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.BlockNumber))
                throw new ValidationException("مقدار شماره بلوک نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.TownShipNumber))
                throw new ValidationException("مقدار شماره شهرک نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.BlockName))
                throw new ValidationException("نام بلوک نمی‌تواند خالی باشد.");

            if (!Guid.TryParse(dto.TownShipNumber, out Guid i))
                throw new ValidationException("مقدار شماره شهرک صحیح نمی‌باشد.");

            if (!Guid.TryParse(dto.BlockNumber, out Guid j))
                throw new ValidationException("مقدار شماره بلوک صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_Blocks(dto, userId);

            if (Res == "0")
                throw new ValidationException("ویرایش بلوک با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("نام بلوک قبلا ثبت شده است.");
            else if (Res == "-3")
                throw new ValidationException("شناسه شهرک یافت نشد.");
            else if (Res == "-4")
                throw new ValidationException("شناسه بلوک یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }
    }
}
