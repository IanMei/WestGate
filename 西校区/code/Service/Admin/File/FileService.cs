using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Account.Dto;
using System.Collections.Generic;
using System.Data;

namespace CMS.Service.Admin {
    public class FileService : IFileService {

        private string fileGet = System.Configuration.ConfigurationSettings.AppSettings["FileDomain"];
        private IBaseRepository<SqlServercfg> bll;
        public FileService(IBaseRepository<SqlServercfg> _bll)
        {
            bll = _bll;
        }

        public ApiResult List()
        {
            var list = new List<FileItem>();
            ParamCollection paraList = new ParamCollection();
            string clause = string.Empty;
            string column = "";

            var query = System.Web.HttpContext.Current.Request.QueryString;
            if (!string.IsNullOrEmpty(query["ref_no"]))
            {
                column = APP_FILE.REF_NO_FIELD;
                clause += string.Format("({0}.{1} = @{1})", APP_FILE.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, query["ref_no"]));
                column = APP_FILE.FILE_TYPE_FIELD;
                clause += string.Format("AND ({0}.{1} = '01')", APP_FILE.TABLE_NAME, column);
                paraList.Clause = clause;
                var queryList = bll.Select<APP_FILE>(paraList, "APP_FILE.SEQ_NO ASC");

                foreach (var item in queryList)
                {
                    var row = item.ConvertTo<FileItem>();
                    row.name = item.FILE_DESC;
                    row.url = WebSettingsConfig.FileDomain + item.FILE_NAME;
                    list.Add(row);
                }
            }
          
            return new ApiResult<List<FileItem>>().SetSuccessResult(list);
        }

        public ApiResult Update(FileForm form)
        {
            if (!string.IsNullOrEmpty(form.ref_no))
            {

                ParamCollection paraList = new ParamCollection();
                string clause = string.Empty;
                string column = "";

                var query = System.Web.HttpContext.Current.Request.QueryString;
                column = APP_FILE.REF_NO_FIELD;
                clause += string.Format("({0}.{1} = @{1})", APP_FILE.TABLE_NAME, column);
                paraList.Add(new ParamData(column, DbType.String, form.ref_no));
                column = APP_FILE.FILE_TYPE_FIELD;
                clause += string.Format("AND ({0}.{1} = '01')", APP_FILE.TABLE_NAME, column);
                paraList.Clause = clause;
                var dbList = bll.Select<APP_FILE>(paraList);
                dbList.ForEach(a => a.CurModel = DealModel.Delete);
                var update = new BaseList();
                int seq = 1;
                foreach (var item in form.list)
                {
                    var ex = dbList.Find(a => a.ID == item.ID);
                    if (ex != null)
                    {
                        ex.CurModel = DealModel.Modify;
                        ex.SEQ_NO = seq;
                    }
                    else
                    {
                        update.Add(new APP_FILE(DealModel.New)
                        {
                            FILE_TYPE = "01",
                            FILE_NAME = item.FILE_NAME,
                            REF_NO = form.ref_no,
                            FILE_DESC = item.FILE_DESC,
                            SEQ_NO = seq,
                            IS_ENABLED = 1
                        });
                    }
                    seq++;
                }
                dbList.ForEach(a => update.Add(a));

                bll.UpdateAllByParams(update);

                return new ApiResult<List<FileItem>>().SetSuccessResult();
            }
            return new ApiResult<List<FileItem>>().SetFailedResult("无效参数");
        }
    }
}
