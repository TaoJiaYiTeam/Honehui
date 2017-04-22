using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao.Facade
{
    public class DailySearchVm
    {
        public string TeacherGuid { get; set; }
        public string StudentGuid { get; set; }
        public int PageSize { get; set; }
        public int OffSet { get; set; }
    }
}
