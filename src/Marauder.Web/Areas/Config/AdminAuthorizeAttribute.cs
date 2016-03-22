using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marauder.Web.Areas.Config
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 檢查用戶是否登入 登入:ture ;沒登入:false
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool _pass = false;
            if (httpContext.Session["Account"] != null) _pass = true;
            return _pass;
        }

        /// <summary>
        /// 該方法為驗證失敗時才會執行，回到管理員登入介面
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Config/Administrator/Login");
        }
    }
}