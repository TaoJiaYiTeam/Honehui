using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Facade;
using Tao.IRepository;
using AutoMapper;
using Tao.Domain;

namespace Tao.Application
{
    public class DailyApp
    {
        private IDailyRepo _dailyRepo;
        private IDailyMissionRepo _dailymissionRepo;
        private IRTeaStuRepo _rTeaStuRepo;
        public DailyApp(IDailyRepo dailyRepo, IDailyMissionRepo dailymissionRepo, IRTeaStuRepo rTeaStuRepo)
        {
            _dailyRepo = dailyRepo;
            _dailymissionRepo = dailymissionRepo;
            _rTeaStuRepo = rTeaStuRepo;
        }
        public IEnumerable<DailyVm> GetAll()
        {
            throw new NotImplementedException();
        }
        public bool Insert(DailyVm entity, string stuGuid)
        {
            var daily = Daily.CreateNew(stuGuid,DateTime.Parse(entity.Date), entity.Content);
            return _dailyRepo.Insert(daily);
        }

        public IEnumerable<EventVm> GetMission(string StuGuid)
        {
            var relation = _rTeaStuRepo.FindOne(new { StudentGuid = StuGuid,IsDel=0 });
            if (null == relation)
            {
                return new List<EventVm>();
            }
            var missions = Mapper.Map<IEnumerable<DailyMissionVm>>(_dailymissionRepo.FindAll(new
            {
                Type = 1,
                IsDel = 0,
                CreateGuid = relation.TeacherGuid
            }));

            IList<EventVm> events = new List<EventVm>();
            foreach (var item in missions)
            {

                var daily=_dailyRepo.FindOne(new { Date = item.Date, UserGuid = StuGuid ,IsDel=0});
                events.Add(new EventVm()
                {
                    allDay = true,
                    className = daily != null ? "done" : "doing",
                    id = item.RowGuid,
                    start = item.Date.ToString("yyyy-MM-dd"),
                    title = item.Title,
                    url= "/Home/Daily?Date="+ item.Date.ToString("yyyy-MM-dd")
                });
            }
            return events;
        }
    }
}
