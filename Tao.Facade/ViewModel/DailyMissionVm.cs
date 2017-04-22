using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tao.Facade
{
    public class DailyMissionVm
    {
        public string RowGuid { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public string CreateGuid { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDone { get; set; }

    }
}