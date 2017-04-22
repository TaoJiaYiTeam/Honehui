using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Infrastructure;

namespace Tao.Domain
{
    public class RTeaStu:IAggregateRoot
    {
        public string RowGuid { get; set; }
        public string TeacherGuid { get; set; }
        public string StudentGuid { get; set; }
        public int IsDel { get;private set; }
        protected RTeaStu() {

        }
        public void Delete()
        {
            IsDel = 1;
        }
        public static RTeaStu CreateNew(string teacherguid,
            string studentguid)
        {
            var rteastu = new RTeaStu()
            {
                RowGuid = UniqueKeyGenerator.CreateNewKey(),
                TeacherGuid = teacherguid,
                StudentGuid = studentguid,
                IsDel = 0
            };
            return rteastu;
        }
    }
}
