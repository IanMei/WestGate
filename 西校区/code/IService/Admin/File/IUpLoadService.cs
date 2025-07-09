using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin
{
    public interface IUpLoadService
    {
        Hashtable UploadPictures(FileInfo info);
        string GetPictureById(decimal decid);
    }
}
