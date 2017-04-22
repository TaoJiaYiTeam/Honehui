using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tao.Repository;

namespace Tao.Application
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(o =>
            {
                o.AddProfile<AppProfiles>();
                o.AddProfile<ModelProfiles>();
            });
        }
    }
}
