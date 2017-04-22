using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using Tao.Facade;

namespace Web.Filters
{
    public class CusAuthorityAttribute : FilterAttribute, IActionFilter
    {
        public string Role = string.Empty;
        public CusAuthorityAttribute() {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var role = filterContext.HttpContext.Session["Role"] as RoleVm;
            if (null != role)
            {
                var roles = Role.Split(',');
                if (!roles.Any(o => o == role.Type.ToString()))
                {
                    filterContext.Result = new RedirectResult("/Main/BadPage");
                }
            }
        }
    }
}