using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Infrastructure;

namespace Tao.Domain
{
    public class User:IAggregateRoot
    {
        public string RowGuid { get;private set; }
        public string UserName { get;private set; }
        public string LogonNo { get;private set; }
        public string Password { get;private set; }
        public int IsDel { get; private set; }
        protected User() {

        }
        public static User CreateNew(string userName,
            string logonNo,
            string password)
        {
            var daily = new User()
            {
                RowGuid = UniqueKeyGenerator.CreateNewKey(),
                UserName = userName,
                LogonNo = logonNo,
                Password = password
            };
            return daily;
        }
        public void Delete()
        {
            IsDel = 1;
        }
    }
}
