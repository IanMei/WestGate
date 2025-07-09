using CMS.Core.Common;
using CMS.IService.Admin.Account.Dto;
using System.Collections.Generic;

namespace CMS.IService.Admin {
    public interface IRoleService {
        ApiResult GetPagedRolesList(int page, int size);
        ApiResult Get(decimal roleId);
        ApiResult Update(RoleInfo role);
        ApiResult Delete(string rodeIdSplitStr);
        ApiResult SetStatus(decimal roleId);
    }
}
