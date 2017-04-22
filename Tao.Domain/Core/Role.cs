using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Infrastructure;

namespace Tao.Domain
{
    public class Role:IAggregateRoot
    {
        public string RowGuid { get;private set; }
        public string Name { get; private set; }
        public int Type { get; private set; }
        public int IsDel { get; private set; }
        protected Role() {

        }
        public static Role CreateNew(string name,
            int type)
        {
            var role = new Role()
            {
                RowGuid = UniqueKeyGenerator.CreateNewKey(),
                Name = name,
                Type = type,
                IsDel = 0
            };
            return role;
        }
    }
}
