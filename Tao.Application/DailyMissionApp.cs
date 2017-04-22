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
    public class DailyMissionApp
    {
        private IDailyMissionRepo _dailymissionRepo;
        private IDailyRepo _dailyRepo;
        private IUserRepo _userRepo;
        private IRTeaStuRepo _teaStuRepo;
        public DailyMissionApp(IDailyMissionRepo dailymissionRepo, IUserRepo userRepo, IRTeaStuRepo teaStuRepo, IDailyRepo dailyRepo)
        {
            _dailymissionRepo = dailymissionRepo;
            _userRepo = userRepo;
            _teaStuRepo = teaStuRepo;
            _dailyRepo = dailyRepo;
        }
        public IEnumerable<DailyVm> GetAll()
        {
            throw new NotImplementedException();
        }
        public bool Insert(DailyMissionVm entity)
        {
            var dailyMission = DailyMission.CreateNew(entity.CreateGuid, entity.Date, entity.Title, 1);
            return _dailymissionRepo.Insert(dailyMission);
        }
        public bool Update(DailyMissionVm entity)
        {
            var model = Mapper.Map<DailyMission>(entity);
            model.Delete();
            _dailymissionRepo.Update(model);
            var dailyMission = DailyMission.CreateNew(entity.CreateGuid, entity.Date, entity.Title, 1);
            return _dailymissionRepo.Insert(dailyMission);
        }
        public bool Delete(DailyMissionVm entity)
        {
            var model = Mapper.Map<DailyMission>(entity);
            model.Delete();
            return _dailymissionRepo.Update(model);
        }
        public IEnumerable<EventVm> GetMission(string TeaGuid)
        {
            var missions = Mapper.Map<IEnumerable<DailyMissionVm>>(_dailymissionRepo.FindAll(new
            {
                Type = 1,
                IsDel = 0,
                CreateGuid = TeaGuid
            }));

            IList<EventVm> events = new List<EventVm>();
            foreach (var item in missions)
            {
                events.Add(new EventVm()
                {
                    allDay = true,
                    className = string.Empty,
                    id = item.RowGuid,
                    start = item.Date.ToString("yyyy-MM-dd"),
                    title = item.Title,
                    url = string.Empty
                });
            }
            return events;
        }


        public IEnumerable<SelectOptionVm> GetStudent(string teaGuid)
        {
            var relation = _teaStuRepo.FindAll(new { TeacherGuid = teaGuid, IsDel = 0 });
            if (null == relation || !relation.Any())
            {
                return new List<SelectOptionVm>();
            }
            var user = _userRepo.FindAll("where RowGuid in @RowGuid", new { RowGuid = relation.Select(o => o.StudentGuid) });

            return user.Select(o => new SelectOptionVm() { id = o.RowGuid, text = o.UserName });
        }
        public IEnumerable<DailyTableVm> GetDaily(DailySearchVm search, out int total)
        {
            var daily = _dailyRepo.GetList(Mapper.Map<DailySearch>(search), out total);
            var result = new List<DailyTableVm>();
            foreach (var item in daily)
            {
                result.Add(new DailyTableVm
                {
                    CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm"),
                    Date = item.Date.ToString("yyyy-MM-dd"),
                    RowGuid = item.RowGuid,
                    UserName = item?.user.UserName
                });
            }
            return result;
        }

        public DailyVm GetDetailInfo(string rowGuid)
        {
            return Mapper.Map<DailyVm>(_dailyRepo.FindOne(new { RowGuid = rowGuid }));
        }

    }
}
