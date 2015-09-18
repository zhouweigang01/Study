using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;


namespace THU.LabSystem.Areas.Admin.Controllers
{
    /// <summary>
    /// THU.LabSystemBE.Deploy.UserTypeEnumDTO.Admin
    /// </summary>
    [AuthExt.RoleAuth(2)]
    public class AdminConsoleController : Controller
    {
        //
        // GET: /Admin/AdminConsole/

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult CommonEnum()
        {
            return View();
        }

        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult TeacherList()
        {
            return View();
        }
        public ActionResult DeviceList()
        {
            return View();
        }
        public ActionResult DeviceAppoint()
        {
            return View();
        }
        public ActionResult RepairDeviceReport()
        {
            return View();
        }
        public ActionResult UseDeviceReport()
        {
            return View();
        }


        #region 文件导出

        public FileResult ExportApplyFile(DateTime start, DateTime end, long device)
        {
            NHExt.Runtime.Proxy.AgentInvoker invoker = new NHExt.Runtime.Proxy.AgentInvoker();
            invoker.AssemblyName = "THU.LabSystemBP.Agent.GetDeviceUseReportBPProxy";
            invoker.DllName = "THU.LabSystemBP.Agent.dll";
            invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "PageIndex", FieldValue = 1 });
            invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "PageSize", FieldValue = 1000 });
            invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "StartTime", FieldValue = start });
            invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "EndTime", FieldValue = end });
            invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "DeviceKey", FieldValue = device });
            invoker.SourcePage = "IWEHAVE.Export";
            THU.LabSystemBE.Deploy.DeviceUseReportExDTO titleReport = invoker.Do<THU.LabSystemBE.Deploy.DeviceUseReportExDTO>();


            IWorkbook workbook = new HSSFWorkbook();
            if (titleReport != null && titleReport.ListData.Count > 0)
            {
                foreach (THU.LabSystemBE.Deploy.DeviceUseReportDTO title in titleReport.ListData)
                {

                    invoker = new NHExt.Runtime.Proxy.AgentInvoker();
                    invoker.AssemblyName = "THU.LabSystemBP.Agent.GetDeviceUseReportBPProxy";
                    invoker.DllName = "THU.LabSystemBP.Agent.dll";
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "PageIndex", FieldValue = 1 });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "PageSize", FieldValue = 1000 });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "StartTime", FieldValue = start });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "EndTime", FieldValue = end });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "Level", FieldValue = 1 });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "TeacherKey", FieldValue = title.TeacherKey });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "DeviceKey", FieldValue = device });
                    THU.LabSystemBE.Deploy.DeviceUseReportExDTO contentReport = invoker.Do<THU.LabSystemBE.Deploy.DeviceUseReportExDTO>();

                    if (contentReport.ListCount <= 0)
                    {
                        continue;
                    }

                    ISheet sheet = workbook.CreateSheet(title.TeacherName);
                    for (int i = 0; i < 8; i++)
                    {
                        sheet.SetColumnWidth(i, 20 * 256);  //设置列宽，50个字符宽度。宽度参数为1/256，故乘以256
                    }
                    IRow row = sheet.CreateRow(0);
                    row.HeightInPoints = 30;

                    ICellStyle style = workbook.CreateCellStyle();
                    style.Alignment = HorizontalAlignment.Center;
                    style.VerticalAlignment = VerticalAlignment.Center;
                    style.FillForegroundColor = IndexedColors.Grey50Percent.Index;
                    style.LeftBorderColor = IndexedColors.Black.Index;
                    style.RightBorderColor = IndexedColors.Black.Index;
                    style.TopBorderColor = IndexedColors.Black.Index;
                    style.BottomBorderColor = IndexedColors.Black.Index;
                    style.BorderLeft = BorderStyle.Thin;
                    style.BorderRight = BorderStyle.Thin;
                    style.BorderTop = BorderStyle.Thin;
                    style.BorderBottom = BorderStyle.Thin;
                    style.FillPattern = FillPattern.SolidForeground;
                    ICell cell = null;
                    string[] titlesStr = { "导师姓名", "开始时间", "结束时间", "使用时间", "单价", "费用", "使用人", "设备号", "设备名称", "房间号" };
                    for (int i = 0; i < titlesStr.Length; i++)
                    {
                        cell = row.CreateCell(i);
                        cell.CellStyle = style;
                        cell.SetCellValue(titlesStr[i]);
                    }

                    ICellStyle style2 = workbook.CreateCellStyle();
                    style2.CloneStyleFrom(style);
                    style2.FillForegroundColor = IndexedColors.LightYellow.Index;
                    IFont font = workbook.CreateFont();
                    font.Boldweight = (short)FontBoldWeight.Bold;
                    style2.SetFont(font);

                    row = sheet.CreateRow(1);
                    row.HeightInPoints = 30;

                    cell = row.CreateCell(0);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.TeacherName);

                    cell = row.CreateCell(1);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.StartTime.ToString("yyyy/MM/dd"));

                    cell = row.CreateCell(2);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.EndTime.ToString("yyyy/MM/dd"));

                    cell = row.CreateCell(3);
                    cell.CellStyle = style2;
                    cell.SetCellValue("-");

                    cell = row.CreateCell(4);
                    cell.CellStyle = style2;
                    cell.SetCellValue("-");

                    cell = row.CreateCell(5);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.Fee.ToString("C"));

                    cell = row.CreateCell(6);
                    cell.CellStyle = style2;
                    cell.SetCellValue("-");

                    cell = row.CreateCell(7);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.SN);

                    cell = row.CreateCell(8);
                    cell.CellStyle = style2;
                    cell.SetCellValue("-");

                    cell = row.CreateCell(9);
                    cell.CellStyle = style2;
                    cell.SetCellValue("-");

                    ICellStyle style3 = workbook.CreateCellStyle();
                    style3.CloneStyleFrom(style);
                    style3.FillForegroundColor = IndexedColors.LightYellow.Index;
                    for (int i = 0; i < contentReport.ListData.Count; i++)
                    {
                        row = sheet.CreateRow(i + 2);
                        row.HeightInPoints = 20;
                        cell = row.CreateCell(0);
                        cell.CellStyle = style3;
                        cell.SetCellValue("");

                        cell = row.CreateCell(1);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].StartTime.ToString("yyyy/MM/dd HH:mm:ss"));

                        cell = row.CreateCell(2);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].EndTime.ToString("yyyy/MM/dd HH:mm:ss"));

                        cell = row.CreateCell(3);
                        cell.CellStyle = style2;
                        cell.SetCellValue(contentReport.ListData[i].Hours.ToString());

                        cell = row.CreateCell(4);
                        cell.CellStyle = style2;
                        cell.SetCellValue(contentReport.ListData[i].Price.ToString("C"));

                        cell = row.CreateCell(5);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].Fee.ToString("C"));

                        cell = row.CreateCell(6);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].UserName);

                        cell = row.CreateCell(7);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].SN);

                        cell = row.CreateCell(8);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].DeviceName);

                        cell = row.CreateCell(9);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].HouseName);
                    }
                }
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return File(ms, "application/vnd.ms-excel", "设备使用记录导出.xls");
        }

        public FileResult ExportRepairFile(DateTime start, DateTime end)
        {
            NHExt.Runtime.Proxy.AgentInvoker invoker = new NHExt.Runtime.Proxy.AgentInvoker();
            invoker.AssemblyName = "THU.LabSystemBP.Agent.GetDeviceRepairReportBPProxy";
            invoker.DllName = "THU.LabSystemBP.Agent.dll";
            invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "PageIndex", FieldValue = 1 });
            invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "PageSize", FieldValue = 1000 });
            invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "StartTime", FieldValue = start });
            invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "EndTime", FieldValue = end });
            invoker.SourcePage = "IWEHAVE.Export";
            THU.LabSystemBE.Deploy.DeviceRepairReportExDTO titleReport = invoker.Do<THU.LabSystemBE.Deploy.DeviceRepairReportExDTO>();


            IWorkbook workbook = new HSSFWorkbook();
            if (titleReport != null && titleReport.ListData.Count > 0)
            {
                foreach (THU.LabSystemBE.Deploy.DeviceRepairReportDTO title in titleReport.ListData)
                {
                    invoker = new NHExt.Runtime.Proxy.AgentInvoker();
                    invoker.AssemblyName = "THU.LabSystemBP.Agent.GetDeviceRepairReportBPProxy";
                    invoker.DllName = "THU.LabSystemBP.Agent.dll";
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "PageIndex", FieldValue = 1 });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "PageSize", FieldValue = 1000 });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "StartTime", FieldValue =start });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "EndTime", FieldValue = end });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "Level", FieldValue = 1 });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "DeviceKey", FieldValue = title.DeviceKey });

                    THU.LabSystemBE.Deploy.DeviceRepairReportExDTO contentReport = invoker.Do<THU.LabSystemBE.Deploy.DeviceRepairReportExDTO>();

                    if (contentReport.ListCount <= 0)
                    {
                        continue;
                    }
                    ISheet sheet = workbook.CreateSheet(title.DeviceName);
                    for (int i = 0; i < 7; i++)
                    {
                        sheet.SetColumnWidth(i, 20 * 256);  //设置列宽，50个字符宽度。宽度参数为1/256，故乘以256
                    }
                    IRow row = sheet.CreateRow(0);
                    row.HeightInPoints = 30;

                    ICellStyle style = workbook.CreateCellStyle();
                    style.Alignment = HorizontalAlignment.Center;
                    style.VerticalAlignment = VerticalAlignment.Center;
                    style.FillForegroundColor = IndexedColors.Grey50Percent.Index;
                    style.LeftBorderColor = IndexedColors.Black.Index;
                    style.RightBorderColor = IndexedColors.Black.Index;
                    style.TopBorderColor = IndexedColors.Black.Index;
                    style.BottomBorderColor = IndexedColors.Black.Index;
                    style.BorderLeft = BorderStyle.Thin;
                    style.BorderRight = BorderStyle.Thin;
                    style.BorderTop = BorderStyle.Thin;
                    style.BorderBottom = BorderStyle.Thin;
                    style.FillPattern = FillPattern.SolidForeground;
                    ICell cell = null;
                    string[] titlesStr = { "设备号", "设备名称", "房间号", "维护日期", "维护费用", "维护次数", "报修原因", "维修方式" };
                    for (int i = 0; i < titlesStr.Length; i++)
                    {
                        cell = row.CreateCell(i);
                        cell.CellStyle = style;
                        cell.SetCellValue(titlesStr[i]);
                    }

                    ICellStyle style2 = workbook.CreateCellStyle();
                    style2.CloneStyleFrom(style);
                    style2.FillForegroundColor = IndexedColors.LightYellow.Index;
                    IFont font = workbook.CreateFont();
                    font.Boldweight = (short)FontBoldWeight.Bold;
                    style2.SetFont(font);

                    row = sheet.CreateRow(1);
                    row.HeightInPoints = 30;

                    cell = row.CreateCell(0);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.SN);

                    cell = row.CreateCell(1);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.DeviceName);

                    cell = row.CreateCell(2);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.HouseName);

                    cell = row.CreateCell(3);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.StartTime);

                    cell = row.CreateCell(4);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.Fee.ToString("C"));

                    cell = row.CreateCell(5);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.Number.ToString());

                    cell = row.CreateCell(6);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.Memo);

                    cell = row.CreateCell(7);
                    cell.CellStyle = style2;
                    cell.SetCellValue(title.RepairMemo);

                    ICellStyle style3 = workbook.CreateCellStyle();
                    style3.CloneStyleFrom(style);
                    style3.FillForegroundColor = IndexedColors.LightYellow.Index;

                    for (int i = 0; i < contentReport.ListData.Count; i++)
                    {
                        row = sheet.CreateRow(i + 2);
                        row.HeightInPoints = 20;
                        cell = row.CreateCell(0);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].SN);

                        cell = row.CreateCell(1);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].DeviceName);

                        cell = row.CreateCell(2);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].HouseName);

                        cell = row.CreateCell(3);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].StartTime);

                        cell = row.CreateCell(4);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].Fee.ToString("C"));

                        cell = row.CreateCell(5);
                        cell.CellStyle = style3;
                        cell.SetCellValue("1");

                        cell = row.CreateCell(6);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].Memo);

                        cell = row.CreateCell(7);
                        cell.CellStyle = style3;
                        cell.SetCellValue(contentReport.ListData[i].RepairMemo);
                    }
                }
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return File(ms, "application/vnd.ms-excel", "设备维护记录导出.xls");
        }

        #endregion

    }
}
