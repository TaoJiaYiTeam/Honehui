using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Infrastructure;

namespace Tao.Domain
{
    public class RRoleMenu:IAggregateRoot
    {
        public string RowGuid { get;private set; }
        public string RoleGuid { get; private set; }
        public string MenuGuid { get; private set; }
        public int IsDel { get; private set; }
        protected RRoleMenu() {

        }
        public static RRoleMenu CreateNew(string roleguid,
            string menuguid)
        {
            var rrolemenu = new RRoleMenu()
            {
                RowGuid = UniqueKeyGenerator.CreateNewKey(),
                RoleGuid = roleguid,
                MenuGuid = menuguid,
                IsDel = 0
            };
            return rrolemenu;
        }
    }
}
