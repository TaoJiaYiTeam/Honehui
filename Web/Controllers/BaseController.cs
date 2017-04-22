using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Filters;
using Tao.Application;
using Tao.Facade;

namespace Web.Controllers
{
    [CustomAction(Order =1)]
    public class BaseController: Controller
    {
        public BaseController()
        {

        }

        private string username = string.Empty;
        public UserVm UserInfo
        {
            get { return Session["User"] as UserVm; }
        }
        public RoleVm Role
        {
            get {
               
                return Session["Role"] as RoleVm;
            }
        }
        public IEnumerable<MenuVm> Menus
        {
            get
            {
                var result = Session["Menu"] as IEnumerable<MenuVm>;
                return result ?? new List<MenuVm>();
            }
        }
    }
}