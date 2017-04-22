using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tao.Application;
using Tao.Facade;
using Web.Filters;

namespace Web.Controllers
{
    [CusAuthority(Order = 2, Role = "0")]
    public class AdminController : BaseController
    {
        private AdminApp _adminApp;
        public AdminController(AdminApp adminApp)
        {
            _adminApp = adminApp;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region 学生管理
        public ActionResult StuManager()
        {

            return View();
        }
        [HttpGet]
        public JsonResult GetInfo(string TeaGuid)
        {
            if (!TeaGuid.Equals("0"))
            {
                var result = _adminApp.GetAllStuByTeacher(TeaGuid);

                return Json(new { total = result.Count(), rows = result },JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { total = 0, rows = new List<UserVm>() },JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetInitInfo()
        {
            var teas = _adminApp.GetTeachers();
            var stus = _adminApp.GetStudents();
            return Json(new { Students = stus, Teachers = teas }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InsertToTeacher(string teaGuid,string stuGuid)
        {
            var flag = false;
            if (string.IsNullOrEmpty(teaGuid))
            {
                return Json(flag);
            }
            if (string.IsNullOrEmpty(stuGuid))
            {
                return Json(flag);
            }
            flag=_adminApp.InsertToTeacher(teaGuid,stuGuid);
            return Json(flag);
        }
        [HttpPost]
        public JsonResult Delete(string stuGuid)
        {

            var flag = false;
            if (string.IsNullOrEmpty(stuGuid))
            {
                return Json(flag);
            }
            flag = _adminApp.DeleteToTeacher(stuGuid);
            return Json(flag);
        }
        #endregion



        #region 用户添加

        public ActionResult UserManager()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUserList(UserSearchVm search)
        {
            int total;
            var result = _adminApp.GetUserList(search, out total);
            return Json(new { total = total, rows = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertUser(UserVm vm)
        {
            if (string.IsNullOrEmpty(vm.LogonNo))
            {
                return Json(false);
            }
            if (string.IsNullOrEmpty(vm.UserName))
            {
                return Json(false);
            }
            if (string.IsNullOrEmpty(vm.PassWord))
            {
                return Json(false);
            }
            if (string.IsNullOrEmpty(vm.RoleGuid))
            {
                return Json(false);
            }
            return Json(_adminApp.InsertUser(vm));

        }

        [HttpPost]
        public JsonResult DeleteUser(UserVm vm)
        {
            return Json(_adminApp.DeleteUser(vm));
        }

        [HttpGet]
        public JsonResult GetRoles()
        {
            return Json(_adminApp.GetRoles(), JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}