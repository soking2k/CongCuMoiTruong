using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CinemaOnline.Areas.Admin.Authorization
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        
        public int Role { set; get; }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var TempData = filterContext.Controller.TempData;
            TempData["Messages"] = "Bạn không có quyền truy cập mục này";
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "action", "E401" },
                    { "controller", "Error" },
                    { "Area", "" }
                });
        }
    }
}