using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tao.Repository
{
    [Table("DailyMission")]
    public class DailyMissionModel
    {
        [Key]
        public string RowGuid { get; set; }
        [NotUpdate]
        public string Title { get; set; }
        [NotUpdate]
        public DateTime Date { get; set; }
        [NotUpdate]
        public int Type { get; set; }
        [NotUpdate]
        public string CreateGuid { get; set; }
        [NotUpdate]
        public DateTime CreateTime { get; set; }
        public int IsDel { get; set; }
        
    }
}
