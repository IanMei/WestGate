using CMS.Core.Common;
using CMS.IService.Admin.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin {
    public interface IFileService {

        ApiResult List();
        ApiResult Update(FileForm item);
    }
}
