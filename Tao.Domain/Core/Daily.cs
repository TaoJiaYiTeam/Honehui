using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Infrastructure;

namespace Tao.Domain
{
    public class Daily:IAggregateRoot
    {
        public string RowGuid { get;private set; }
        public string UserGuid { get; private set; }
        public DateTime Date { get; private set; }
        public string Content { get; private set; }
        public int IsDel { get; private set; }
        public DateTime CreateTime { get; private set; }

        public User user { get;private set; }
        protected Daily() {

        }
        public static Daily CreateNew(string userguid,
            DateTime date,
            string content)
        {
            var daily = new Daily()
            {
                RowGuid = UniqueKeyGenerator.CreateNewKey(),
                Content = content,
                CreateTime = DateTime.Now,
                Date = date,
                IsDel = 0,
                UserGuid = userguid
            };
            return daily;
        }
        public void SetUser(User user) {
            this.user = user;
        }
    }
}
