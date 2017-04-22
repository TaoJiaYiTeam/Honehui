using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tao.Application;

namespace Web.Controllers
{
    public class MainController : BaseController
    {
        public MainController()
        {


        }
        // GET: Main
        public ActionResult Index()
        {
            ViewBag.UserName = UserInfo.UserName;
            return View();
        }
        public ActionResult BadPage()
        {

            return View();
        }
    }
}