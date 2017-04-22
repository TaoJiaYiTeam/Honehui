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
    [CusAuthority(Order = 2, Role = "2")]
    public class TeacherController : BaseController
    {
        DailyMissionApp _dailyMissionApp;
        public TeacherController(DailyMissionApp dailyMissionApp)
        {
            _dailyMissionApp = dailyMissionApp;
        }
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AddMission(DailyMissionVm vm)
        {
            vm.CreateGuid = UserInfo.RowGuid;
            vm.Type = 1;
            _dailyMissionApp.Insert(vm);
            return Json(true);
        }
        public JsonResult ChangeMission(DailyMissionVm vm)
        {
            vm.CreateGuid = UserInfo.RowGuid;
            vm.Type = 1;
            _dailyMissionApp.Update(vm);
            return Json(true);
        }
        public JsonResult DeleteMission(DailyMissionVm vm)
        {
            vm.CreateGuid = UserInfo.RowGuid;
            vm.Type = 1;
            var flag = _dailyMissionApp.Delete(vm);
            return Json(new { Flag = flag });
        }
        [HttpGet]
        public JsonResult GetDaily()
        {
            var result = _dailyMissionApp.GetMission(UserInfo.RowGuid);
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult StudentDaily()
        {

            return View();
        }

        [HttpGet]
        public JsonResult GetStudents(string q, int page=0)
        {
           var result= _dailyMissionApp.GetStudent(UserInfo.RowGuid).ToList();
            result.Insert(0, new SelectOptionVm() { id = "0", text = "全部" });
            return Json(new { items = result } , JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTableDaily(DailySearchVm search)
        {
            int total;
            search.TeacherGuid = UserInfo.RowGuid;
            var result = _dailyMissionApp.GetDaily(search, out total);
            return Json(new { total = total, rows = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetailInfo(string rowGuid)
        {
            return Json(_dailyMissionApp.GetDetailInfo(rowGuid),JsonRequestBehavior.AllowGet);
        }
    }
}