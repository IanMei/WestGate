using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ElementUI.Admin.Controllers
{
    public class MetaInfo : ActionFilterAttribute
    {
        public string copyright { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.mate = Meta();
        }

        private string Meta(string copyright, string keywords, string description, string author)
        {
            StringBuilder s = new StringBuilder();
            string MetaTemplate = @"<meta name = ""Copyright"" content=""#copyright#"" />
    <meta name=""keywords"" content=""#keywords#"" />
    <meta name=""description"" content=""#description#"" />
    <meta name=""author"" content=""#author#"" />";
            return MetaTemplate.Replace("#copyright#", copyright)
                .Replace("#keywords#", keywords)
                .Replace("#description#", description)
                .Replace("#author#", author);
        }

        private string Meta()
        {
            string copyright = "带玩,DaiWan";
            string keywords = "英雄联盟,lol,DaiWan,Game,游戏,lol攻略,lol视频,英雄资料,英雄,攻略";
            string description = "DaiWan LOL英雄联盟,为英雄联盟玩家提供最全的英雄联盟出装攻略、英雄联盟视频、客户端下载、战斗力查询、英雄皮肤、最全的英雄资料和物品等信息,掌握第一手资料,不遗漏任何一条英雄联盟的信息,更多精彩";
            string author = "带玩游戏平台";
            return Meta(copyright, keywords, description, author);
        }
    }
}