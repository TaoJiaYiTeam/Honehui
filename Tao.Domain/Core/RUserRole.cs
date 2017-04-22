using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Infrastructure;

namespace Tao.Domain
{
    public class RUserRole:IAggregateRoot
    {
        public string RowGuid { get;private set; }
        public string UserGuid { get;private set; }
        public string RoleGuid { get;private set; }
        public int IsDel { get;private set; }
        protected RUserRole() {

        }
        public static RUserRole CreateNew(string userGuid,
            string roleGuid)
        {
            var ruserrole = new RUserRole()
            {
                RowGuid = UniqueKeyGenerator.CreateNewKey(),
                UserGuid = userGuid,
                RoleGuid = roleGuid,
                IsDel = 0
            };
            return ruserrole;
        }
        public void Delete()
        {
            IsDel = 1;
        }
    }
}
