using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using TestKayakNancy.Services;

namespace TestKayakNancy.Application
{
    public class MyApplicationModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IService>().To<Service>();
        }
    }
}
