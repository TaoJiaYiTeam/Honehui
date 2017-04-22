using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tao.Application;
using Tao.Facade;

namespace Web.Controllers
{
    public class LogonController : Controller
    {
        private UserApp _userApp;
        public LogonController(UserApp userApp) {

            _userApp = userApp;
        }
        // GET: Logon
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Logon(string Name,string Password)
        {
            var flag = false;
            UserVm user ;
            RoleVm role ;
            IEnumerable<MenuVm> menus ;
            if (_userApp.isCanLogon(Name, Password, out user, out role, out menus))
            {
                flag = true;
                Session["User"] = user;
                Session["Role"] = role;
                Session["Menu"] = menus;
            }
            return Json(new {Flag= flag, Msg= flag ?"登陆成功":"用户或者密码错误"});
        }
        public ActionResult LogonOut()
        {
            Session["User"] = null;
            Session["Role"] = null;
            Session["Menu"] = null;
            return RedirectToAction("Index");
        }

      
    }
}