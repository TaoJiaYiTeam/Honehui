using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tao.Repository
{
    [Table("Daily")]
    public class DailyModel
    {
        [Key]
        public string RowGuid { get; set; }
        public string UserGuid { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int IsDel { get; set; }
        
    }
}
