using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using Tao.Facade;

namespace Web.Filters
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["User"] as UserVm;
            var role = filterContext.HttpContext.Session["Role"] as RoleVm;
            if (null == user || null == role)
            {
                filterContext.Result = new RedirectResult("/Logon/Index");
            }
        }
    }
}