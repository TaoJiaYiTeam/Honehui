using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Infrastructure;

namespace Tao.Domain
{
    public class DailyMission: IAggregateRoot
    {
        public string RowGuid { get;private set; }
        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public int Type { get; private set; }
        public string CreateGuid { get; private set; }
        public DateTime CreateTime { get; private set; }
        public int IsDel { get; private set; }
        protected DailyMission() {

        }
        public static DailyMission CreateNew(string creator,
            DateTime date,
            string title,
            int type)
        {
            var dailymission = new DailyMission()
            {
                RowGuid = UniqueKeyGenerator.CreateNewKey(),
                Date = date,
                IsDel = 0,
                CreateTime=DateTime.Now,
                CreateGuid = creator,
                Title=title,
                Type=type
            };
            return dailymission;
        }
        public void Delete()
        {
            IsDel = 1;
        }
    }
}
