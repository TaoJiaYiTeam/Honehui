using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Domain;
using Tao.Infrastructure;
using Tao.IRepository;

namespace Tao.Repository
{
    public class UserRepo : BaseRepository<User, UserModel>, IUserRepo
    {
        public IEnumerable<User> GetList(UserSearch search, out int total)
        {
            var sqlCount = new StringBuilder(@"select 
                                                    count(1) 
                                                from 
                                                    User t1 
                                                where 
                                                    1=1");
            var partialsql = new StringBuilder(@"select 
                                                    * 
                                                from 
                                                    User t1
                                                where 
                                                    1=1");
            var whereSql = new StringBuilder();
            whereSql.Append(" and t1.IsDel=0 ");

            using (var conn = DbClient.GetConnection())
            {
                total = conn.ExecuteScalar<int>(sqlCount.Append(whereSql).ToString(), search);
                string sql = partialsql.Append(whereSql).ToString() + " limit " + search.OffSet + " ," + search.PageSize;
                var model = conn.Query<User>(sql, search);
                return model;
            }
        }
    }
}
