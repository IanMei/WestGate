using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;

namespace CMS.IService.Admin.Account.Dto {
    public class FileItem : APP_FILE {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class FileForm {
        public FileForm()
        {
            list = new List<FileItem>();
        }

        public string ref_no { get; set; }

        public List<FileItem> list { get; set; }

    }

    public class FileResult
    {
        public string FileNames { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public string FileLength { get; set; }
        public string ContentTypes { get; set; }
        public string OriginalNames { get; set; }
        public string Status { get; set; }
        public string Msg { get; set; }
    }
}
