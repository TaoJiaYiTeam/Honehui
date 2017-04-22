using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao.Domain
{
    public class DailySearch
    {
        public string TeacherGuid { get; set; }
        public string StudentGuid { get; set; }
        public int PageSize { get; set; }
        public int OffSet { get; set; }
    }
}
