using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tao.Facade;
using Tao.Application;
using System.Web.Routing;
using Web.Filters;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        private DailyApp _dailyApp;
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
        public HomeController(DailyApp dailyApp)
        {
            base.ControllerContext = this.ControllerContext;
            _dailyApp = dailyApp;
        }
        [CusAuthority(Order =2,Role ="1")]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        [CusAuthority(Order = 2, Role = "1")]
        public JsonResult GetDaily()
        {
            var result = _dailyApp.GetMission(UserInfo.RowGuid);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [CusAuthority(Order = 2, Role = "1")]
        public ActionResult Daily(DateTime date)
        {
            ViewBag.DateStr = date.ToString("yyyy-MM-dd");
            ViewBag.UserName = UserInfo.UserName;
            return View();
        }
        [HttpPost]
        [CusAuthority(Order = 2, Role = "1")]
        public ActionResult AddDaily(DailyVm entity)
        {
            if (_dailyApp.Insert(entity,UserInfo.RowGuid))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Daily", new { date = entity.Date });
            }
        }

        public PartialViewResult Menu()
        {

            return PartialView(Menus);
        }
    }
}