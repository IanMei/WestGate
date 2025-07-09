using CMS.Core.Common;
using CMS.IService.Admin.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin {
    public interface IOrganService {

        ApiResult List(int page, int size);
        ApiResult Get(decimal id);
        ApiResult Update(OrganDto item);
        ApiResult Delete(string ids);
        ApiResult State(decimal id);
    }
}
