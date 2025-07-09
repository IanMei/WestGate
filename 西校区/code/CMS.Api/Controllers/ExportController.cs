using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Judges.Dto;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ElementUI.Admin.Controllers
{
    public class ExportController : Controller
    {
        private readonly IQuestionnaireService service;

        public ExportController(IQuestionnaireService _service)
        {
            service = _service;
        }

        // GET: Export
        public ActionResult Questionnaire(decimal id)
        {
            var info = service.Result(id) as ApiResult<List<QuestionnaireResultDto>>;

            var data = info.Data;


            var list = from s in data
                       group s by s.JUDGES_NO into g
                       select new { g.Key, 
                           name = g.Max(a => a.NICK_NAME), 
                           company = g.Max(a => a.COMPANY),
                           position = g.Max(a => a.POSITION),
                           link_tel = g.Max(a => a.LINK_TEL),
                           wechat = g.Max(a => a.WECHAT),
                           email = g.Max(a => a.EMAIL),
                           link_man = g.Max(a => a.LINK_MAN)
                       };

            HSSFWorkbook workbook = new HSSFWorkbook();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息

                si.Subject = "主题信息";//填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion


            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("问卷调查表");


            int rowIndex = 0;
            foreach (var item in list)
            {

                IRow nameRow = sheet.CreateRow(rowIndex);
                ICellStyle nameStyle = workbook.CreateCellStyle();
                nameRow.Height = 500;
                HSSFFont font = (HSSFFont)workbook.CreateFont();
                font.FontHeightInPoints = 15;
                font.Boldweight = 700;
                nameStyle.SetFont(font);

                nameRow.CreateCell(0).SetCellValue(item.name);
                nameRow.GetCell(0).CellStyle = nameStyle;


                rowIndex++;
                IRow rowHSSF = sheet.CreateRow(rowIndex);
                rowHSSF.Height = 10 * 200;
                ICell notesTitle = rowHSSF.CreateCell(0);
                ICellStyle notesStyle = workbook.CreateCellStyle();

                notesStyle.VerticalAlignment = VerticalAlignment.Center;

                notesStyle.BorderBottom = BorderStyle.Thin;
                notesStyle.BorderLeft = BorderStyle.Thin;
                notesStyle.BorderTop = BorderStyle.Thin;
                notesStyle.WrapText = true;//设置换行这个要先设置


                var sb = new StringBuilder();
                sb.Append($"联系人：{item.link_man}\n");
                sb.Append($"所在单位：{item.company}\n");
                sb.Append($"职务：{item.position}\n");
                sb.Append($"电话：{item.link_tel}\n");
                sb.Append($"邮件：{item.email}\n");
                sb.Append($"微信：{item.wechat}");

                rowHSSF.CreateCell(0).SetCellValue(sb.ToString());
                rowHSSF.GetCell(0).CellStyle = notesStyle;//设置换行

                ICellStyle notallStyle = workbook.CreateCellStyle();

                notallStyle.VerticalAlignment = VerticalAlignment.Center;

                notallStyle.BorderBottom = BorderStyle.Thin;
                notallStyle.BorderTop = BorderStyle.Thin;


                ICellStyle notleftStyle = workbook.CreateCellStyle();

                notleftStyle.VerticalAlignment = VerticalAlignment.Center;

                notleftStyle.BorderBottom = BorderStyle.Thin;
                notleftStyle.BorderTop = BorderStyle.Thin;
                notleftStyle.BorderRight = BorderStyle.Thin;

                rowHSSF.CreateCell(1).CellStyle = notallStyle;//设置换行
                rowHSSF.CreateCell(2).CellStyle = notleftStyle;//设置换行
                rowIndex += 1;

                #region 列头及样式
                {
                    HSSFRow headerRow = (HSSFRow)sheet.CreateRow(rowIndex);
                    headerRow.Height = 400;
                    HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                    HSSFFont fontx = (HSSFFont)workbook.CreateFont();
                    fontx.FontHeightInPoints = 12;
                    fontx.Boldweight = 700;
                    headStyle.SetFont(fontx);


                    headStyle.BorderBottom = BorderStyle.Thin;
                    headStyle.BorderLeft = BorderStyle.Thin;
                    headStyle.BorderRight = BorderStyle.Thin;
                    headStyle.BorderTop = BorderStyle.Thin;

                    headerRow.CreateCell(0).SetCellValue("问题");
                    headerRow.GetCell(0).CellStyle = headStyle;


                    headerRow.CreateCell(1).SetCellValue("推荐学校");
                    headerRow.GetCell(1).CellStyle = headStyle;

                    headerRow.CreateCell(2).SetCellValue("原因");
                    headerRow.GetCell(2).CellStyle = headStyle;

                }
                rowIndex += 1;
                #endregion

                var detail = data.FindAll(a => a.JUDGES_NO == item.Key);
                int index = 0;
                int start = 0;
                var mergedRegion = new Dictionary<int, int>();
                foreach (var row in detail)
                {
                    HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);


                    HSSFCellStyle rowStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                    rowStyle.BorderBottom = BorderStyle.Thin;
                    rowStyle.BorderLeft = BorderStyle.Thin;
                    rowStyle.BorderRight = BorderStyle.Thin;
                    rowStyle.BorderTop = BorderStyle.Thin;
                    rowStyle.VerticalAlignment = VerticalAlignment.Center;
                    //rowStyle.Alignment = HorizontalAlignment.Center;
                    if (index > 0)
                    {
                        if (detail[index - 1].ITEM_ID != row.ITEM_ID)
                        {
                            dataRow.CreateCell(0).SetCellValue(row.TITLE);
                            dataRow.GetCell(0).CellStyle = rowStyle;
                            mergedRegion.Add(start, rowIndex -1);
                            start = rowIndex;
                        }
                        else
                        {
                            dataRow.CreateCell(0).CellStyle = rowStyle;
                            if (index == detail.Count - 1) {

                                mergedRegion.Add(start, rowIndex);
                            }
                        }
                    }
                    else
                    {
                        dataRow.CreateCell(0).SetCellValue(row.TITLE);
                        dataRow.GetCell(0).CellStyle = rowStyle;
                        start = rowIndex;
                    }

                    dataRow.CreateCell(1).SetCellValue(row.SCHOOL_NAME);
                    dataRow.GetCell(1).CellStyle = rowStyle;

                    dataRow.CreateCell(2).SetCellValue(row.REASON);
                    dataRow.GetCell(2).CellStyle = rowStyle;

                    rowIndex++;
                    index++;
                }
                foreach (var region in mergedRegion) {

                    sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(region.Key, region.Value, 0, 0));
                }

                rowIndex = rowIndex + 2;
            }

            sheet.AutoSizeColumn(1);
            sheet.AutoSizeColumn(2);
            sheet.SetColumnWidth(0, 50 * 256);
            var curContext = System.Web.HttpContext.Current;

            // 设置编码和附件格式

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = Encoding.UTF8;
                curContext.Response.Charset = "";
                curContext.Response.AppendHeader("Content-Disposition",
                    "attachment;filename=" + HttpUtility.UrlEncode("问卷调查表.xls", Encoding.UTF8));
                curContext.Response.BinaryWrite(ms.GetBuffer());
                curContext.Response.End();
            }

            return Content("导出成功");
        }


    }
}