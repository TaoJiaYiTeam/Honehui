using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tao.Repository;

namespace Tao.Application
{
    public class AutoFacExt
    {
        private static IContainer _container;
        private static readonly ContainerBuilder _builder = new ContainerBuilder();

        public static void RegisterApplication()
        {

            //注册AppService
            _builder.RegisterAssemblyTypes(typeof(DailyApp).Assembly)
                .Where(t => t.Name.EndsWith("App"));

            //注册DomainService
            //_builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CompenateDomService))).Where
            //   (t => t.Name.EndsWith("Service"));

            //注册Repository
            _builder.RegisterAssemblyTypes(typeof(DailyRepo).Assembly)
                .Where(t => t.Namespace.Equals("Tao.Repository"))
                .AsImplementedInterfaces().InstancePerDependency();

        }

        public static ContainerBuilder Builder { get { return _builder; } }

        public static void SetContainer(IContainer container)
        {
            _container = container;
        }

        public static T GetFromFac<T>()
        {
            return _container.Resolve<T>();
        }
    }
}