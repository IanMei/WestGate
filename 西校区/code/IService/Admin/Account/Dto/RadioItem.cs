using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IService.Admin.Account.Dto {
    public class RadioItem {
        public string key { get; set; }
        public string text { get; set; }
    }

    public class DropdownItem {
        public DropdownItem()
        {
        }
        public string Value { get; set; }
        public string Label { get; set; }
    }

    public class SubjectItem {
        public SubjectItem()
        {
            leaf = 0;
        }
        public int leaf { get; set; }
        public string Value { get; set; }
        public string Label { get; set; }
        public List<SubjectItem> Children { get; set; }
    }

    public class AreaItem {
        public AreaItem()
        {
        }
        public string value { get; set; }
        public string label { get; set; }
        public IList<AreaItem> children { get; set; }
    }
}
