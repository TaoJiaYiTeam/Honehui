using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Domain;
using Tao.Infrastructure;
using Tao.IRepository;
using Dapper;

namespace Tao.Repository
{
    public class DailyRepo : BaseRepository<Daily, DailyModel>, IDailyRepo
    {
        public IEnumerable<Daily> GetList(DailySearch search,out int total)
        {
            var sqlCount = new StringBuilder(@"select 
                                                    count(1) 
                                                from 
                                                    Daily t1 
                                                inner join 
                                                    (select * from User where IsDel=0) t2 on t2.RowGuid=t1.UserGuid 
                                                inner join 
                                                    (select * from R_Tea_Stu where IsDel=0) t3 on t2.RowGuid=t3.StudentGuid  
                                                where 
                                                    1=1");
            var partialsql = new StringBuilder(@"select 
                                                    t1.*,t2.*,t3.*  
                                                from 
                                                    Daily t1
                                                inner join 
                                                    (select * from User where IsDel=0) t2 on t2.RowGuid=t1.UserGuid 
                                                inner join 
                                                    (select * from R_Tea_Stu where IsDel=0) t3 on t2.RowGuid=t3.StudentGuid  
                                                where 
                                                    1=1");
            var whereSql = new StringBuilder();
            if (!search.StudentGuid.Equals("0"))
            {
                whereSql.Append(" and t1.UserGuid = @StudentGuid ");
            }

            whereSql.Append(" and t3.TeacherGuid=@TeacherGuid ");

            whereSql.Append(" and t1.IsDel=0 ");

            using (var conn = DbClient.GetConnection())
            {
                total = conn.ExecuteScalar<int>(sqlCount.Append(whereSql).ToString(), search);
                string sql = partialsql.Append(whereSql).ToString() + "order by t1.CreateTime desc limit " + search.OffSet + " ," + search.PageSize;
                var model = conn.Query<Daily,User,RTeaStu,Daily>(sql, (x,y,z)=> { x.SetUser(y);return x; },search,null,true,"RowGuid");
                return model;
            }
           


        }
    }
}
