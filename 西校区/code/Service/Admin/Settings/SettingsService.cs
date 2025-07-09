using CMS.Core.Common;
using CMS.Core.Common.TableExtend;
using CMS.Core.Responsity;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using CMS.IService;
using CMS.IService.Admin;
using CMS.IService.Admin.Settings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Service.Admin.Settings
{
    public class SettingsService : ISettingsService
    {
        private IBaseRepository<SqlServercfg> bll;
        public SettingsService(IBaseRepository<SqlServercfg> _bll)
        {
            bll = _bll;
        }

        public ApiResult GetInfo()
        {
            var queryDb = bll.Select<APP_SETUP>();
            if (queryDb != null && queryDb.Count  > 0)
            {
                var rs = queryDb[0];
                var info = rs.ConvertTo<SettingsDto>();
                info.questionnaire = rs.IS_OPEN_QUESTIONNAIRE == 1;
                if (!string.IsNullOrEmpty(rs.HOT_SEARCH))
                {
                    info.tags = rs.HOT_SEARCH.Split(new char[] { '|' }).ToList();
                }
                var linkList = bll.Select<APP_LINK>(new ParamCollection(), "APP_LINK.CREATE_TIME ASC");
                foreach (APP_LINK item in linkList)
                {
                    info.details.Add(item.ConvertTo<LinkDto>());
                }
                return new ApiResult<SettingsDto>().SetSuccessResult(info);
            }
            return new ApiResult<SettingsDto>().SetFailedResult("暂无数据");
        }

        public ApiResult Update(SettingsDto form)
        {
            var item = form.ConvertTo<APP_SETUP>();
            if (item != null)
            {
                item.CurModel = DealModel.Modify;
                item.IS_OPEN_QUESTIONNAIRE = form.questionnaire ? 1 : 0;

                if (form.tags != null && form.tags.Count > 0)
                {
                    var tagStr = "";
                    foreach (var tag in form.tags)
                    {
                        tagStr += tag + "|";
                    }
                    if (!string.IsNullOrEmpty(tagStr) && tagStr.Length > 0)
                    {
                        tagStr = tagStr.Remove(tagStr.Length - 1);

                    }
                    item.HOT_SEARCH = tagStr;
                }

                var detail = new BaseList();
                var dbData = bll.Select<APP_LINK>(new ParamCollection(), "APP_LINK.CREATE_TIME ASC");
                dbData.ForEach(a => a.CurModel = DealModel.Delete);
                foreach (LinkDto ditem in form.details)
                {
                    var ex = dbData.Find(a => a.ID == ditem.ID);
                    if (ex != null)
                    {
                        ex.CurModel = DealModel.Modify;
                    }
                    var row = ditem.ConvertTo<APP_LINK>();
                    row.LINK_NAME = ditem.LINK_NAME;
                    row.LINK_URL = ditem.LINK_URL;
                    row.IMAGE_ID = ditem.IMAGE_ID;
                    detail.Add(row);
                }
                dbData.ForEach(a =>
                {
                    if (a.CurModel == DealModel.Delete)
                    {
                        detail.Add(a);
                    }
                });
                var id = bll.UpdateMasterDetail(item, detail);
                if (id > 0)
                {
                    return new ApiResult().SetSuccessResult();
                }
            }
            return new ApiResult().SetFailedResult("更新失败");
        }
    }
}
