using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Domain;
using Tao.IRepository;

namespace Tao.Repository
{
    public class DailyMissionRepo : BaseRepository<DailyMission, DailyMissionModel>, IDailyMissionRepo
    {

    }
}
