using DataAccess.DTOs.Plot;
using DataAccess.Interfaces;
using DataAccess.Models.Plot;
using PropertyManagementProject.Data;
using PropertyManagementProject.Response.Exceptions;
using System.Data;

namespace PropertyManagementProject.Services.Plot
{
    public class PlotServices : IPlotServices
    {
        public async Task<bool> ChangeStatus(ChangeStatusPlot changeStatus, string UserId)
        {
            if (string.IsNullOrEmpty(changeStatus.Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(changeStatus.Number, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForPlots(changeStatus.Number, changeStatus.Status, UserId, 0);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت قطعه با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("قطعه مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Delete(DeletePlotRequest deletePlot, string userId)
        {
            if (string.IsNullOrEmpty(deletePlot.Number))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(deletePlot.Number, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_ChangeStatus_ForPlots(deletePlot.Number, true, userId, 1);

            if (Res == "0")
                throw new ValidationException("تغییر وضعیت قطعه با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("قطعه مورد نظر یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<List<PlotResponse>> GetAll(Plot_Search _Search)
        {
            if (!new[] { -1, 0, 1, 2, 3, 4, 5, 6 }.Contains(_Search.Type))
                throw new ValidationException("مقدار وارد شده برای نوع جستجو معتبر نمی‌باشد.");

            if (!new[] { 0, 1, 2 }.Contains(_Search.TypeStatus))
                throw new ValidationException("نوع جستجو وضعیت معتبر نمی‌باشد.");

            if (!new[] { -1, 0, 1, 2 }.Contains(_Search.SubType))
                throw new ValidationException("مقدار وارد شده برای نوع جستجو دوم معتبر نمی‌باشد.");

            if (_Search.Value == null)
                throw new ValidationException("مقدار عبارت جستجو شده نامعتبر می‌باشد.");

            if (_Search.SubValue == null)
                throw new ValidationException("مقدار عبارت جستجو شده دوم نامعتبر می‌باشد.");

            if (!long.TryParse(_Search.SubValue, out long l) && !string.IsNullOrEmpty(_Search.SubValue))
                throw new ValidationException("مقدار وارد شده جستجو شده دوم نامعتبر می‌باشد.");

            if (!int.TryParse(_Search.Page, out int i))
                throw new ValidationException("مقدار وارد شده صفحه نامعتبر می‌باشد.");

            if (!int.TryParse(_Search.OffSet, out int j))
                throw new ValidationException("مقدار وارد شده تعداد نامعتبر می‌باشد.");

            if (Convert.ToInt32(_Search.Page) < 1)
                throw new ValidationException("مقدار وارد شده صفحه باید حداقل 1 ‌باشد.");

            if (Convert.ToInt32(_Search.OffSet) < 10)
                throw new ValidationException("مقدار وارد شده تعداد باید حداقل 10 ‌باشد.");

            DataTable? Plots = await DbConnectionFactory.DbInstance.Pr_Select_Plots("0", _Search.Type.ToString(), _Search.SubType.ToString(), _Search.TypeStatus.ToString(),
                _Search.Value, _Search.SubValue, _Search.Page, _Search.OffSet);

            if (Plots == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            List<PlotResponse> lstPlotsResponse = new List<PlotResponse>();

            foreach (DataRow row in Plots.Rows)
            {
                lstPlotsResponse.Add(new PlotResponse
                {
                    PlotNumber = row["PlotNumber"]?.ToString() ?? string.Empty,
                    TownShipName = row["TownShipName"]?.ToString() ?? string.Empty,
                    BlockName = row["BlockName"]?.ToString() ?? string.Empty,
                    PlotName = row["PlotName"]?.ToString() ?? string.Empty,
                    Area = row["Area"]?.ToString() ?? string.Empty,
                    LandUseTypeName = row["LandUseTypeName"]?.ToString() ?? string.Empty,
                    CadastralNumber = row["CadastralNumber"]?.ToString() ?? string.Empty,
                    StatusText = row["StatusText"]?.ToString() ?? string.Empty,
                    TotalCount = row["TotalCount"]?.ToString() ?? string.Empty
                });
            }

            return lstPlotsResponse;
        }

        public async Task<PlotResponse> GetById(GetPlotsById plotsById)
        {
            if (string.IsNullOrEmpty(plotsById.PlotNumber))
                throw new ValidationException("اطلاعات وارد شده صحیح نمی‌باشد.");

            if (!Guid.TryParse(plotsById.PlotNumber, out Guid i))
                throw new ValidationException("مقدار شماره صحیح نمی‌باشد.");

            DataTable? Plots = await DbConnectionFactory.DbInstance.Pr_Select_Plots(plotsById.PlotNumber);

            if (Plots == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            if (Plots.Rows.Count == 0)
                throw new ValidationException("قطعه‌ای یافت نشد.");

            return new PlotResponse
            {
                TownShipNumber = Plots.Rows[0]["TownShipNumber"]?.ToString() ?? string.Empty,
                BlockNumber = Plots.Rows[0]["BlockNumber"]?.ToString() ?? string.Empty,
                PlotNumber = Plots.Rows[0]["PlotNumber"]?.ToString() ?? string.Empty,
                TownShipName = Plots.Rows[0]["TownShipName"]?.ToString() ?? string.Empty,
                BlockName = Plots.Rows[0]["BlockName"]?.ToString() ?? string.Empty,
                PlotName = Plots.Rows[0]["PlotName"]?.ToString() ?? string.Empty,
                Area = Plots.Rows[0]["Area"]?.ToString() ?? string.Empty,
                LandUseTypeNumber = Plots.Rows[0]["LandUseTypeNumber"]?.ToString() ?? string.Empty,
                LandUseTypeName = Plots.Rows[0]["LandUseTypeName"]?.ToString() ?? string.Empty,
                CadastralNumber = Plots.Rows[0]["CadastralNumber"]?.ToString() ?? string.Empty,
                StatusText = Plots.Rows[0]["StatusText"]?.ToString() ?? string.Empty,
                TotalCount = "1"
            };
        }

        public async Task<List<LandUseTypeResponse>> GetLandUseType()
        {
            DataTable? LandUseTypes = await DbConnectionFactory.DbInstance.Pr_Select_LandUseTypes();

            if (LandUseTypes == null)
                throw new ValidationException("دریافت داده با خطا مواجه شد.");

            List<LandUseTypeResponse> lstLandUseTypesResponse = new List<LandUseTypeResponse>();

            foreach (DataRow row in LandUseTypes.Rows)
            {
                lstLandUseTypesResponse.Add(new LandUseTypeResponse
                {
                    Number = row["Number"]?.ToString() ?? string.Empty,
                    Name = row["Name"]?.ToString() ?? string.Empty
                });
            }

            return lstLandUseTypesResponse;
        }

        public async Task<bool> Insert(Plot_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.TownShipNumber))
                throw new ValidationException("مقدار شماره شهرک نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.BlockNumber))
                throw new ValidationException("مقدار شماره بلوک نمی‌تواند خالی باشد.");

            if (!Guid.TryParse(dto.TownShipNumber, out Guid i))
                throw new ValidationException("مقدار شماره شهرک صحیح نمی‌باشد.");

            if (!Guid.TryParse(dto.BlockNumber, out Guid j) && dto.BlockNumber != "0")
                throw new ValidationException("مقدار شماره بلوک صحیح نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.PlotName))
                throw new ValidationException("نام قطعه نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.Area))
                throw new ValidationException("مقدار متراژ نمی‌تواند خالی باشد.");

            if (!long.TryParse(dto.Area, out long l))
                throw new ValidationException("مقدار متراژ صحیح نمی‌باشد.");

            if (!Guid.TryParse(dto.LandUseType, out Guid k))
                throw new ValidationException("مقدار شماره نوع کاربری صحیح نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.CadastralNumber))
                throw new ValidationException("نام پلاک ثبتی نمی‌تواند خالی باشد.");

            dto.PlotNumber = "000";

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_Plots(dto, userId);

            if (Res == "0")
                throw new ValidationException("ثبت قطعه با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("نام قطعه قبلا ثبت شده است.");
            else if (Res == "-3")
                throw new ValidationException("شناسه شهرک یافت نشد.");
            else if (Res == "-4")
                throw new ValidationException("شناسه بلوک یافت نشد.");
            else if (Res == "-5")
                throw new ValidationException("شناسه قطعه یافت نشد.");
            else if (Res == "-6")
                throw new ValidationException("نوع کاربری قطعه یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }

        public async Task<bool> Update(Plot_InsUp dto, string userId)
        {
            if (string.IsNullOrEmpty(dto.TownShipNumber))
                throw new ValidationException("مقدار شماره شهرک نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.BlockNumber))
                throw new ValidationException("مقدار شماره بلوک نمی‌تواند خالی باشد.");

            if (!Guid.TryParse(dto.TownShipNumber, out Guid i))
                throw new ValidationException("مقدار شماره شهرک صحیح نمی‌باشد.");

            if (!Guid.TryParse(dto.BlockNumber, out Guid j) && dto.BlockNumber != "0")
                throw new ValidationException("مقدار شماره بلوک صحیح نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.PlotName))
                throw new ValidationException("نام قطعه نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.Area))
                throw new ValidationException("مقدار متراژ نمی‌تواند خالی باشد.");

            if (!long.TryParse(dto.Area, out long l))
                throw new ValidationException("مقدار متراژ صحیح نمی‌باشد.");

            if (!Guid.TryParse(dto.LandUseType, out Guid k))
                throw new ValidationException("مقدار شماره نوع کاربری صحیح نمی‌باشد.");

            if (string.IsNullOrEmpty(dto.CadastralNumber))
                throw new ValidationException("نام پلاک ثبتی نمی‌تواند خالی باشد.");

            if (string.IsNullOrEmpty(dto.PlotNumber))
                throw new ValidationException("مقدار شماره قطعه نمی‌تواند خالی باشد.");

            if (!Guid.TryParse(dto.PlotNumber, out Guid h))
                throw new ValidationException("مقدار شماره قطعه صحیح نمی‌باشد.");

            string Res = await DbConnectionFactory.DbInstance.Pr_InsUp_Plots(dto, userId);

            if (Res == "0")
                throw new ValidationException("ویرایش قطعه با خطا مواجه شد.");
            else if (Res == "-1")
                throw new ValidationException("کاربر درخواست دهنده یافت نشد.");
            else if (Res == "-2")
                throw new ValidationException("نام قطعه قبلا در این شهرک و بلوک ثبت شده است.");
            else if (Res == "-3")
                throw new ValidationException("شناسه شهرک یافت نشد.");
            else if (Res == "-4")
                throw new ValidationException("شناسه بلوک یافت نشد.");
            else if (Res == "-5")
                throw new ValidationException("شناسه قطعه یافت نشد.");
            else if (Res == "-6")
                throw new ValidationException("نوع کاربری قطعه یافت نشد.");
            else if (Res == "-500")
                throw new ValidationException("خطای غیر منتظره در دیتابیس");

            return true;
        }
    }
}
